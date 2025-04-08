<?php
session_start();

if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_SESSION['order_id'])) {
    // Connect to the database
    $connection = mysqli_connect('awseb-e-ccnmsqhepk-stack-awsebrdsdatabase-w0hjmlkwsq41.cbeu2m0uuauu.us-east-1.rds.amazonaws.com', 'uts', 'utsuts123', 'assignment2');

    // Check connection
    if (mysqli_connect_errno()) {
        echo "Failed to connect to MySQL: " . mysqli_connect_error();
        exit;
    }

    $orderId = $_SESSION['order_id'];
    $carModel = $_SESSION['car_model'];
    $quantity = $_SESSION['quantity'];

    // Update order status in the database
    $sql = "UPDATE orders SET status='confirmed' WHERE order_id=$orderId";
    if (mysqli_query($connection, $sql)) {
        // Successfully updated status

        // Load the JSON file
        $jsonString = file_get_contents('cars.json');
        $data = json_decode($jsonString, true);

        // Find the car model in the JSON and update the quantity
        foreach ($data['cars'] as &$car) {
            if ($car['model'] == $carModel) {
                $car['quantity'] -= $quantity;
                break;
            }
        }

        // Save the updated JSON file
        file_put_contents('cars.json', json_encode($data));

        echo "Order confirmed and car quantity updated.";
		//direct to index.php
		header("Location: index.php");
    } else {
        echo "Error updating order: " . mysqli_error($connection);
    }

    // Close the database connection
    mysqli_close($connection);
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
    <title>Marketnya Ngab</title> 
    <link rel="icon" type="image/png" href="image/favicon.ico" />
    <link rel="stylesheet" href="style.css">
    <script src="main.js" defer></script> 
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.0/font/bootstrap-icons.css">
    <style>
        .button-container {
            text-align: center;
            margin-top: 20px;
        }
        .back-to-home-button {
            display: inline-block;
            width: 140px;
            padding: 10px 20px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 5px;
            text-decoration: none;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }
        .back-to-home-button:hover {
            background-color: #0056b3;
        }
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
            perspective: 1000px;
        }
        .navigator:hover {
            transform: rotateY(360deg);
            color: #b63636;
        }
    </style>
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
                            <div>&nbsp;<a class="navigator" href="">Reserve a Car</a> &nbsp;</div>
                        </div>
                    </div>
                </form>
            </div>
        </nav>

        <!-- container -->
        <section class="main__view">
            <!-- Side bar -->  
            <section id="side">
                <!-- Navbar top level menu -->
                <div class="side__menu"></div>          
            </section>

            <!-- Main -->
            <section id="main">
                <div class="section__container">
                    <div class="checkout__form">
                        <h1>Thank You for Your Order!</h1>
                        <p>We appreciate your order and it has been placed.</p>

                        <?php
                        // Ensure session variables are set
                        if (isset($_SESSION['order_id']) && isset($_SESSION['user_email']) && isset($_SESSION['user_mobile']) && isset($_SESSION['car_model']) && isset($_SESSION['rent_start_date']) && isset($_SESSION['rent_end_date']) && isset($_SESSION['quantity']) && isset($_SESSION['price']) && isset($_SESSION['status'])) {
                            $orderId = $_SESSION['order_id'];
                            $email = $_SESSION['user_email'];
                            $mobileNumber = $_SESSION['user_mobile'];
                            $model = $_SESSION['car_model'];
                            $startDate = $_SESSION['rent_start_date'];
                            $endDate = $_SESSION['rent_end_date'];
                            $quantity = $_SESSION['quantity'];
                            $price = $_SESSION['price'];
                            $status = $_SESSION['status'];

                            // Print out the order details
                            echo "<p><strong>Order Number:</strong> $orderId</p>";
                            echo "<p><strong>Email:</strong> $email</p>";
                            echo "<p><strong>Mobile:</strong> $mobileNumber</p>";
                            echo "<p><strong>Car Model Reserved:</strong> $model</p>";
                            echo "<p><strong>Rent Start Date:</strong> $startDate</p>";
                            echo "<p><strong>Rent End Date:</strong> $endDate</p>";
                            echo "<p><strong>Quantity of cars rented:</strong> $quantity</p>";
                            echo "<p><strong>Total Price:</strong> $price</p>";
                            echo "<p><strong>Status:</strong> $status</p>";
                            echo "<div class='button-container'>";
                            echo "<form method='post' action=''>";
                            echo "<button type='submit' class='back-to-home-button'>Confirm Order?</button>";
                            echo "</form>";
                            echo "</div>";
                        } else {
                            echo "<p>Order details not found. Please try again.</p>";
                        }
                        ?>
                    </div>
                </div>
            </section>
        </section>  
    </section>
</body>
</html>
