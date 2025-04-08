<?php
session_start();

// Check if the form is submitted
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Connect to the database
    $connection = mysqli_connect('awseb-e-ccnmsqhepk-stack-awsebrdsdatabase-w0hjmlkwsq41.cbeu2m0uuauu.us-east-1.rds.amazonaws.com', 'uts', 'utsuts123', 'assignment2');

    // Check connection
    if (mysqli_connect_errno()) {
        echo "Failed to connect to MySQL: " . mysqli_connect_error();
        exit;
    }

    // Retrieve and sanitize form inputs
    $carModel = mysqli_real_escape_string($connection, $_POST['carModel']);
    $quantity = (int)mysqli_real_escape_string($connection, $_POST['quantity']);
    $startDate = mysqli_real_escape_string($connection, $_POST['startDate']);
    $endDate = mysqli_real_escape_string($connection, $_POST['endDate']);
    $totalCost = mysqli_real_escape_string($connection, $_POST['totalCost']);
    $name = mysqli_real_escape_string($connection, $_POST['name']);
    $mobileNumber = mysqli_real_escape_string($connection, $_POST['mobileNumber']);
    $email = mysqli_real_escape_string($connection, $_POST['email']);
    $driverLicense = isset($_POST['driverLicense']) ? 1 : 0; // Checkbox value

    // Extract numeric value from totalCost
    $totalCost = floatval(preg_replace('/[^\d.]/', '', $totalCost));

    // Calculate the number of rental days
    $startDateObj = new DateTime($startDate);
    $endDateObj = new DateTime($endDate);
    $diff = $startDateObj->diff($endDateObj);
    $days = $diff->days;

    /*// Calculate price per day
    $pricePerDay = $totalCost / ($quantity * $days);*/

    // Insert the reservation data into the database
    $sql = "INSERT INTO orders (user_email, user_mobile, car_model, rent_start_date, rent_end_date, quantity, price, status) 
            VALUES ('$email', '$mobileNumber', '$carModel', '$startDate', '$endDate', '$quantity', '$totalCost', 'unconfirmed')";

    if (mysqli_query($connection, $sql)) {
        // Get the last inserted order ID
        $orderId = mysqli_insert_id($connection);

        // Store order details in session variables
        $_SESSION['order_id'] = $orderId;
        $_SESSION['user_email'] = $email;
        $_SESSION['user_mobile'] = $mobileNumber;
        $_SESSION['car_model'] = $carModel;
        $_SESSION['rent_start_date'] = $startDate;
        $_SESSION['rent_end_date'] = $endDate;
        $_SESSION['quantity'] = $quantity;
        $_SESSION['price'] = $totalCost;
        $_SESSION['status'] = 'unconfirmed';
        
        echo "Reservation successful!";
        header("Location: confirmation_page.php"); // Redirect to a confirmation page
        exit;
    } else {
        echo "Error: " . $sql . "<br>" . mysqli_error($connection);
    }

    // Close the database connection
    mysqli_close($connection);
}
?>
