<?php
session_start();

// Read the JSON file
$jsonData = file_get_contents('cars.json');
$cars = json_decode($jsonData, true)['cars'];

// Connect to the database
$connection = mysqli_connect('awseb-e-ccnmsqhepk-stack-awsebrdsdatabase-w0hjmlkwsq41.cbeu2m0uuauu.us-east-1.rds.amazonaws.com', 'uts', 'utsuts123', 'assignment2');

// Check connection
if (mysqli_connect_errno()) {
    echo "Failed to connect to MySQL: " . mysqli_connect_error();
    exit;
}

// Check if a car ID is provided in the URL
if (isset($_GET['id'])) {
    $carId = $_GET['id'];

    // Find the car details from the JSON data
    $car = array_filter($cars, function($c) use ($carId) {
        return $c['id'] == $carId;
    });

    if (!empty($car)) {
        $car = array_shift($car);
        $carModel = $car['model'];
        $carYear = $car['model_year'];
        $pricePerDay = $car['pricePerDay'];
    } else {
        echo "Car not found.";
    }
} else {
    // Retrieve the latest uncompleted order for the user
    $userEmail = $_SESSION['user_email']; // Assuming you have a session variable for the user's email
    $uncompleted_reservation = $_SESSION['uncompleted_reservation'] ?? null;

    if ($uncompleted_reservation) {
        $carModel = $uncompleted_reservation['carModel'];
        $carYear = $uncompleted_reservation['carYear'];
    } else {
        $carModel = "";
        $carYear = "";
    }
    $sql = "SELECT car_model FROM orders WHERE user_email = '$userEmail' AND status = 'unconfirmed' ORDER BY order_id DESC LIMIT 1";
    $result = $connection->query($sql);

    if ($result->num_rows > 0) {
        $row = $result->fetch_assoc();
        $carModel = $row['car_model'];
        $carYear = $row['car_year'];
    } else {
        $carModel = "";
        $carYear = "";
    }
}

// Retrieve the availability for the selected car model
$availability = array_filter($cars, function($c) use ($carModel) {
    return $c['model'] == $carModel;
});

$filteredCars = array_filter($cars, function($c) use ($carModel) {
    return $c['model'] == $carModel;
});

if (!empty($filteredCars)) {
    $availability = array_shift($filteredCars)['quantity'];
} else {
    $availability = 0; // or any other appropriate default value
}

?>




<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel='stylesheet' href='style.css'>
        <script src="https://kit.fontawesome.com/e5ece60744.js" crossorigin="anonymous"></script>
        <link href="https://fonts.googleapis.com/css2?family=Open+Sans:wght@400;600;700&display=swap" rel="stylesheet">
        <title>Car Rental System</title>
        <link rel="icon" type="image/png" href="image/favicon.ico" />
        <link rel="stylesheet" href="style.css">
        <script src="main.js"></script>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" crossorigin="anonymous">
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.0/font/bootstrap-icons.css">
        <style>
            .searchbar {
                display: flex;
            }
            .navbar__navigator {
                display: flex;
            }
            .navigator {
                color: #000;
                text-decoration: none;
                display: inline-block;
                transition: transform 0.6s;
                transform-style: preserve-3d;
                perspective: 1000px; /* Gives depth to the flip effect */
            }
            .navigator:hover {
                transform: rotateY(360deg);
                color: #b63636;
            }
        </style>
        <script>
            function calculateTotalCost() {
                var startDate = new Date(document.getElementById('startDate').value);
                document.getElementById('endDate').min = document.getElementById('startDate').value;
                var endDate = new Date(document.getElementById('endDate').value);
                var timeDiff = Math.abs(endDate.getTime() - startDate.getTime());
                var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));
                var quantity = document.getElementById('quantity').value;
                var pricePerDay = <?php echo $pricePerDay; ?>;
                var totalCost = quantity * pricePerDay * diffDays;
                document.getElementById('totalCost').value = '$' + totalCost.toFixed(2);
            }
            
            function clearForm() {
                document.getElementById('reservationForm').reset();
                document.getElementById('totalCost').value = '';
            }
        </script>
    </head>
    <body>
        <section class="all">
            <!-- Navbar -->
            <nav id="navbar">
                <div class="navbar__logo">
                <a href="index.php"><img src="image/logo.png" width="106" height="60"></a>
                </div>
                <!-- reserve navigation -->
                <div class="navbar__navigator"></div>
                <!-- search bar -->
                <div class="navbar__search">
                    <form id="search-form">
                        <div class="searchbar">
                        <div class="navbar__navigator">
                            <div>&nbsp;<a class="navigator">Reserve a Car</a> &nbsp;</div>
                        </div>
                        <!--<input
                            type="search"
                            id="mySearch"
                            name="q"
                            placeholder="Search cars"
                            autocomplete="off"
                            onkeyup="showHints(this.value)"
                            onblur="hideHints()"
                            onfocus="showRecentSearches()">
                        <button class="search-button" type="submit"><i class="fas fa-search"></i></button>
                        </div>
                        <div id="hints-box" class="hints-box" style="display: none;"></div>-->
                    </form>
                </div>
                
            </nav>
            <!-- container -->
            <section class="main__view">
                <!-- Side bar -->  
                <section id="side">
                <!-- Navbar top level menu -->
                    <div class="side__menu">

                    </div>          
                </section>
                <!-- Main -->
                <section id="main">
                    <div class="section__container">
                        <div class="checkout__form">
                        <h1>Reservation</h1>

                        <form id="reservationForm" method="post" action="confirm_order.php">
                            <table>
                                <tr>
                                    <td for="carModel" class="checkout-text">Car Model:</td>
                                    <td><input type="text" id="carModel" name="carModel" value="<?php echo $carModel; ?>" style="color: grey; font-weight: bold;" readonly></td>
                                </tr>
                                <tr>
                                    <td for="carYear" class="checkout-text">Car Year:</td>
                                    <td><input type="text" id="carYear" name="carYear" value="<?php echo $carYear; ?>" style="color: grey; font-weight: bold;" readonly></td>
                                </tr>
                                <tr>
                                    <td for="quantity" class="checkout-text">Quantity:<span style="color:red ">*</span></td>
                                    <td><input type="number" id="quantity" name="quantity" min="1" max="<?php echo $availability; ?>" value="1" onInput="calculateTotalCost()" required></td>
                                </tr>
                                <tr>
                                    <td for="startDate" class="checkout-text">Start Date: <span style="color:red">*</span></td>
                                    <td><input type="date" id="startDate" name="startDate" onInput="calculateTotalCost()" required></td>
                                </tr>
                                <tr></tr>
                                    <td for="endDate" class="checkout-text">End Date:<span style="color:red">*</span></td>
                                    <td><input type="date" id="endDate" name="endDate" onInput="calculateTotalCost()" required></td>
                                </tr>
                                <tr>
                                    <td for="totalCost" class="checkout-text">Total Cost:</td>
                                    <td><input type="text" id="totalCost" name="totalCost" style="color: grey; font-weight: bold;" readonly></td>
                                </tr> 
                                <tr>
                                    <td for="name" class="checkout-text">Name:<span style="color:red">*</span></td>
                                    <td><input type="text" id="name" placeholder= "John Doe" name="name" required></td>
                                </tr>
                                <tr>
                                    <td for="mobileNumber" class="checkout-text">Mobile Number:<span style="color:red">*</span></td>
                                    <td><input type="tel" id="mobileNumber" name="mobileNumber" placeholder= "+61123456789" pattern="(\+61|0)[ ]?\d{1,2}[ ]?\d{2,3}[ ]?\d{2,3}[ ]?\d{2,3}" required></td>
                                </tr>
                                <tr>
                                    <td for="email" class="checkout-text">Email:<span style="color:red">*</span></td>
                                    <td><input type="email" id="email" name="email" placeholder= "john.doe@gmail.com" required></td>
                                </tr>
                                <tr>
                                    <td for="driverLicense" class="checkout-text">Do you have a valid driver's license?<span style="color:red">*</span></td>
                                    <td><input type="checkbox" id="driverLicense" name="driverLicense" required></td>
                                </tr>
                            </table>
                            <button type="submit">Submit</button>
                            <button type="button" onclick="cancelReservation()">Cancel</button>
                        </form>

                        <script>
                            // JavaScript code for real-time cost calculation and form validation
                            $(document).ready(function() {

                                // Regular expressions
                                var mobileRegex = /^(?:\+?61|0)[1-9](?: ?\d){8}$/;
                                var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
                        
                                // Form validation
                                $('#reservationForm').submit(function(event) {
                                    const name = $('#name').val().trim();
                                    const mobileNumber = $('#mobileNumber').val().trim();
                                    const email = $('#email').val().trim();
                                    const driverLicense = $('#driverLicense').is(':checked');

                                    if (!name) {
                                        alert('Please enter your name.');
                                        event.preventDefault();
                                    } else if (!mobileNumber || !mobileRegex.test(mobileNumber)) {
                                        alert('Please enter a valid 10-digit mobile number.');
                                        event.preventDefault();
                                    } else if (!email || !emailRegex.test(email)) {
                                        alert('Please enter a valid email address.');
                                        event.preventDefault();
                                    } else if (!driverLicense) {
                                        alert('Please confirm that you have a valid driver\'s license.');
                                        event.preventDefault();
                                    }
                                });
                            });

                            function cancelReservation() {
                                
                                clearForm();
                                // Redirect the user to the homepage
                                window.location.href = "index.php";
                            }
                            window.addEventListener('beforeunload', function(event) {
                                event.preventDefault();
                                event.returnValue = ''; // Required for some browsers

                                // Gather form data
                                const formData = {
                                    carModel: document.getElementById('carModel').value,
                                    carYear: document.getElementById('carYear').value,
                                    quantity: document.getElementById('quantity').value,
                                    startDate: document.getElementById('startDate').value,
                                    endDate: document.getElementById('endDate').value,
                                    totalCost: document.getElementById('totalCost').value,
                                    name: document.getElementById('name').value,
                                    mobileNumber: document.getElementById('mobileNumber').value,
                                    email: document.getElementById('email').value,
                                    driverLicense: document.getElementById('driverLicense').checked
                                };

                                // Store form data in the user's session
                                <?php
                                $_SESSION['uncompleted_reservation'] = $formData;
                                ?>
                            });
                        </script>
                        </div>
                    </div>
                </section>
            </section>
        </section>
    </body>
</html>