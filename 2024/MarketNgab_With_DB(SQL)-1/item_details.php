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
        <link rel="icon" type="image/png" href="image/favicon.png" />
        <link rel="stylesheet" href="style.css">
        <script src="main.js" defer></script>        
    </head>
    
    <body>

<?php


if (isset($_GET['id'])) {
    $id = $_GET['id'];
    $connection = mysqli_connect('awseb-e-isdrgcrqu3-stack-awsebrdsdatabase-ezaonabyn2pg.cbeu2m0uuauu.us-east-1.rds.amazonaws.com', 'uts', 'utsuts123', 'assignment1');// servername, username, password, db_name
    $query = "SELECT * FROM products WHERE product_id = $id";
    $result = mysqli_query($connection, $query);
    // Display the product details
    if (mysqli_num_rows($result) > 0) {
        $row = mysqli_fetch_array($result);
        echo '<div class="product__detail_item">';
        echo '<h2 class="margin1">' . $row['product_name'] . '</h2>';
        echo '<img src="image/products/' . $row['product_id'] . '.png" alt="img" class="product__detail_img" >';
        echo '<p class="margin2">$' . $row['unit_price'] . ' per item</p>';
        echo '<p class="margin2">Number of Stock: ' . $row['in_stock'] . '</p>';
        // Check if the product is in stock
        // Display the add-to-cart form
        if ($row['in_stock'] > 0) {
            echo '<form action="index.php" method="POST">';
            echo '<input type="hidden" name="productName" value="' . $row['product_name'] . '">';
            echo '<input type="hidden" name="price" value="' . $row['unit_price'] . '">';
            echo '<p class="margin2"> '. $row['prod_description'] . '</p>';
            echo '</form>';
        } else {
            echo '<p class="margin2">This item is currently out of stock.</p>';
        }
    } else {
        echo '<p>Invalid product ID.</p>';
    }
// Display an error message if the product ID is not provided
} else {

}

?>

    </body>
</html>