<?php
session_start();

// Database connection
$connection = mysqli_connect('awseb-e-ccnmsqhepk-stack-awsebrdsdatabase-w0hjmlkwsq41.cbeu2m0uuauu.us-east-1.rds.amazonaws.com', 'uts', 'utsuts123', 'assignment2');

// Check connection
if (mysqli_connect_errno()) {
    echo "Failed to connect to MySQL: " . mysqli_connect_error();
    exit;
}

// Fetch available cars from the database
$sql = "SELECT * FROM orders WHERE quantity > 0";
$result = mysqli_query($connection, $sql);

$products = [];
if ($result) {
    while ($row = mysqli_fetch_assoc($result)) {
        $products[] = $row;
    }
}

// Handle search query
$orderDetails = null;
if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['order_id'])) {
    $searchOrderId = intval($_POST['order_id']);

    $sql = "SELECT * FROM orders WHERE order_id = $searchOrderId";
    $orderResult = mysqli_query($connection, $sql);

    if ($orderResult && mysqli_num_rows($orderResult) > 0) {
        $orderDetails = mysqli_fetch_assoc($orderResult);
    } else {
        $error = "No order found with the given Order ID.";
    }
}

// Check if form is submitted to confirm the order
if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['confirm_order']) && isset($_SESSION['order_id'])) {
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
    } else {
        echo "Error updating order: " . mysqli_error($connection);
    }
}

// Close the database connection
mysqli_close($connection);
?>

<!DOCTYPE html>
<html>
<head>
    <title>Rental Car Checker</title>
    <link rel="stylesheet" href="style.css">
    <style>
        .empty-cart {
            text-align: center;
        }
        .car-list, .order-details {
            width: 80%;
            margin: auto;
            border-collapse: collapse;
        }
        .car-list th, .car-list td, .order-details th, .order-details td {
            border: 1px solid #ddd;
            padding: 8px;
        }
        .car-list th, .order-details th {
            background-color: #f2f2f2;
			color:#333;
        }
        .button-container {
            text-align: center;
            margin-top: 20px;
        }
        .back-to-home-button {
            display: inline-block;
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
    </style>
</head>
<body>

<h2 class="empty-cart">Rental Car Checker</h2>

<!-- Search Form -->
<form method="post" action="">
    <div class="button-container">
        <input type="text" name="order_id" placeholder="Enter Order ID" autocomplete=off required>
        <button type="submit" class="back-to-home-button">Search Order</button>
    </div>
</form>

<?php if (isset($orderDetails)): ?>
    <h2 class="empty-cart">Order Details</h2>
    <table class="order-details" >
        <tr>
            <th>Order ID</th>
			<th>Email</th>
			<th>Mobile</th>
			<th>Car Model</th>
			<th>Rent Start Date</th>
			<th>Rent End Date</th>
			<th>Quantity</th>
			<th>Price</th>
			<th>Status</th>

        </tr>
        <tr>
			<td><?php echo htmlspecialchars($orderDetails['order_id']); ?></td>
            <td><?php echo htmlspecialchars($orderDetails['user_email']); ?></td>
        	<td><?php echo htmlspecialchars($orderDetails['user_mobile']); ?></td>
			<td><?php echo htmlspecialchars($orderDetails['car_model']); ?></td>
			<td><?php echo htmlspecialchars($orderDetails['rent_start_date']); ?></td>
			<td><?php echo htmlspecialchars($orderDetails['rent_end_date']); ?></td>
			<td><?php echo htmlspecialchars($orderDetails['quantity']); ?></td>
			<td><?php echo htmlspecialchars($orderDetails['price']); ?></td>
			<td><?php echo htmlspecialchars($orderDetails['status']); ?></td>
		</tr>
    </table>
<?php elseif (isset($error)): ?>
    <p class="empty-cart"><?php echo htmlspecialchars($error); ?></p>
<?php endif; ?>
</body>
</html>
