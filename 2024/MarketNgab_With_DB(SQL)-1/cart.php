<?php

// Retrieve cart functionality
if (isset($_GET['retrieve_cart'])) {
    if (isset($_SESSION['products']) && !empty($_SESSION['products'])) {
        $response = array(
            'success' => true,
            'products' => $_SESSION['products']
        );
        echo json_encode($response);
    } else {
        $response = array(
            'success' => false,
            'message' => 'The cart is empty'
        );
        echo json_encode($response);
    }
    exit; // Exit after sending the response
}
session_start();

$delete_name = isset($_POST['delete_name'])? htmlspecialchars($_POST['delete_name'], ENT_QUOTES, 'utf-8') : '';
$empty_cart = isset($_POST['empty_cart']);
$clear_cart = isset($_POST['clear_cart']);


if($delete_name != '') unset($_SESSION['products'][$delete_name]);
if(isset($_POST['empty_cart'])) unset($_SESSION['products']);
if ($clear_cart) unset($_SESSION['products']);

$total = 0;
$products = isset($_SESSION['products'])? $_SESSION['products']:[];


foreach($products as $name => $product){
	$subtotal = (double)$product['unit_price']*(double)$product['count'];
	$total += $subtotal;
}

$name = isset($_POST['product_name'])? htmlspecialchars($_POST['product_name'], ENT_QUOTES, 'utf-8') : '';
$price = isset($_POST['unit_price'])? htmlspecialchars($_POST['unit_price'], ENT_QUOTES, 'utf-8') : '';
$count = isset($_POST['count'])? htmlspecialchars($_POST['count'], ENT_QUOTES, 'utf-8') : '';
$id = isset($_POST['product_id'])? htmlspecialchars($_POST['product_id'], ENT_QUOTES, 'utf-8') : '';
$quantity = isset($_POST['unit_quantity'])? htmlspecialchars($_POST['unit_quantity'], ENT_QUOTES, 'utf-8') : '';
?>


<?php

if(isset($_SESSION['products'])){
	$products = $_SESSION['products'];
	foreach($products as $key => $product){
 		if($key == $name){ 
			$count = (double)$count + (double)$product['count'];
		}
	}
}

if($name!=''&&$count!=''&&$price!=''){
	$_SESSION['products'][$name]=[
		'count' => $count,
		'unit_price' => $price
	];
}

$products = isset($_SESSION['products'])? $_SESSION['products']:[];

// Update cart functionality
if (isset($_POST['update_cart'])) {
    $product_names = isset($_POST['product_name']) ? $_POST['product_name'] : [];
    $unit_prices = isset($_POST['unit_price']) ? $_POST['unit_price'] : [];
    $counts = isset($_POST['count']) ? $_POST['count'] : [];

    // Clear the existing cart data
    unset($_SESSION['products']);

    // Update the cart data with the received data
    for ($i = 0; $i < count($product_names); $i++) {
        $name = htmlspecialchars($product_names[$i], ENT_QUOTES, 'utf-8');
        $price = htmlspecialchars($unit_prices[$i], ENT_QUOTES, 'utf-8');
        $count = htmlspecialchars($counts[$i], ENT_QUOTES, 'utf-8');

        if ($name != '' && $count != '' && $price != '') {
            $_SESSION['products'][$name] = [
                'count' => $count,
                'unit_price' => $price
            ];
        }
    }

    // Exit after updating the cart data
    exit;
}
?>

<?php
if ($clear_cart) {
    unset($_SESSION['products']);
}


?>


<!-- end add -->

<script>
function updateQuantity(name, price) {
	var quantity = parseInt(document.getElementsByName(name + 'unit_quantity')[0].value);
	if (quantity > 25) {
		alert('You cannot add more than 25 items of the same product');
		document.getElementsByName(name + 'unit_quantity')[0].value = 25;
		quantity = 25;
	}

	if (quantity === 50) {
		alert('You cannot proceed with an order of 25 items of the same product');
		document.getElementsByName(name + 'unit_quantity')[0].value = 1;
		quantity = 1;
	}

	var productPrice = quantity * price;
	document.getElementById(name + 'unit_price').innerHTML = '$' + productPrice;

	var total = 0;
	var prices = document.querySelectorAll('td[id$="unit_price"]');
	for (var i = 0; i < prices.length; i++) {
		total += parseFloat(prices[i].innerHTML.replace('$', ''));
	}

	document.getElementById('total').innerHTML = '$' + total;
}

// Function to update the cart table with retrieved cart data
function updateCartTable(products) {
    var tableBody = document.querySelector('.cart-table tbody');
    if (Object.keys(products).length === 0) {
        tableBody.innerHTML = '<tr><td colspan="5">Your cart is empty.</td></tr>';
        return;
    }
    // Clear existing rows
    tableBody.innerHTML = '';
    // Add rows for each product
    for (var name in products) {
        if (products.hasOwnProperty(name)) {
            var product = products[name];
            var row = "<tr>" +
                "<td>" + name + "</td>" +
                "<td class='text-right'>$" + product.unit_price + "</td>" +
                "<td class='text-right'><input type='number' name='" + name + "unit_quantity' value='" + product.count + "' min='1' max='25' onchange='updateQuantity(\"" + name + "\", " + product.unit_price + ")'></td>" +
                "<td class='text-right' id='" + name + "unit_price'>$" + (product.unit_price * product.count) + "</td>" +
                "<td><form action='cart.php' method='post'><input type='hidden' name='delete_name' value='" + name + "'><button type='submit' class='delete-btn'>Delete</button></form></td>" +
                "</tr>";
            tableBody.innerHTML += row;
        }
    }
}

// Function to clear the shopping cart
function clearCart() {
    if (confirm("Are you sure to clear all products shopping cart?")) {
        // Clear the cart data from the session
        savedCartData = null;
		updateCartTable([]);
		// Send an AJAX request to clear the cart
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "cart.php", true);
        xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        xhr.onreadystatechange = function() {
            if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
				location.reload();
            }
        };
        xhr.send("clear_cart=true");
    }
}
// Function to retrieve the shopping cart
function retrieveCart() {
	console.log('Retrieving cart...');
	// Send an AJAX request to retrieve the cart
	var xhr = new XMLHttpRequest();
	xhr.open("GET", "cart.php?retrieve_cart=true", true);
	xhr.onreadystatechange = function() {
		if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
			// Handle the response from the server
			var response = JSON.parse(xhr.responseText);
			if (response.success) {
				// Reload the page to reflect the retrieved cart
				updateCartTable(response.products);
			} else {
				alert(response.message);
			}
		}
	};
	xhr.send();
}
</script>
<html>
	<head>
		<title>cart</title>
		<link rel="stylesheet" href="style.css"> 
		<style>
			.checkStock {
				color: #ffffff;
			}
			#cartRetrievever {
				display: flex;
  				justify-content: space-evenly;
				gap: 10px;
			}
			.retrieve_placeOrder {
				border-radius: var(--size-border-radius);
				border: 1px solid var(--color-beige);
				font-size: small;
				width: 45%;
				color: var(--color-red);
				background-color: var(--color-beige);
				padding: 12px 2px;
				display: flex;
				align-content: center;
				align-items: center;
				text-align: center;
				justify-content: center;
				cursor: pointer;
				opacity: 0.4;
			}

			.retrieve_placeOrder:hover {
				background-color: #ff8c8c;
				color: white;
			}

			.retrieve_placeOrder:active {
				background-color: #ff6666;
				color: white;
			}
			.retrieveCartBtn {
				border-radius: var(--size-border-radius);
				border: 1px solid var(--color-beige);
				font-size: small;
				width: 45%;
				color: var(--color-red);
				background-color: var(--color-beige);
				padding: 12px 2px;
				display: flex;
				align-content: center;
				align-items: center;
				text-align: center;
				justify-content: center;
				cursor: pointer;
			}

			.retrieveCartBtn:hover {
				background-color: #ff8c8c;
				color: white;
			}

			.retrieveCartBtn:active {
				background-color: #ff6666;
				color: white;
			}
			.cart-btn {
				display: flex;
				justify-content: space-evenly;
				gap: 10px;
			}
			.checkout-btn {
				border-radius: var(--size-border-radius);
				border: 1px solid var(--color-beige);
				font-size: small;
				width: 45%;
				color: var(--color-red);
				background-color: var(--color-beige);
				padding: 12px 2px;
				display: flex;
				align-content: center;
				align-items: center;
				text-align: center;
				justify-content: center;
				cursor: pointer;
			}

			.checkout-btn:hover {
				background-color: #ff8c8c;
				color: white;
			}

			.checkout-btn:active {
				background-color: #ff6666;
				color: white;
			}


			.clear-cart-btn {
				border-radius: var(--size-border-radius);
				border: 1px solid var(--color-beige);
				font-size: small;
				width: 45%;
				color: var(--color-red);
				background-color: var(--color-beige);
				padding: 12px 2px;
				display: flex;
				align-content: center;
				align-items: center;
				text-align: center;
				justify-content: center;
				cursor: pointer;
			}

			.clear-cart-btn:hover {
				background-color: #ff8c8c;
				color: white;
			}

			.clear-cart-btn:active {
				background-color: #ff6666;
				color: white;
			}
		</style>

	</head>
	<body>

<?php if(empty($products)): ?>
	<h4 class="empty-cart">Shopping Cart</h4>
	<p class="empty-cart">Your Shopping Cart is Empty.</p>
	<br>
	<div id="cartRetrievever">
		<button class="retrieveCartBtn" onclick="retrieveCart()">Retrieve Cart</button>
		<button type="button" class="retrieve_placeOrder">Place an Order</button>
	</div>

	

<?php else: ?>
	<div class="cart__table">


		<table class="cart-table">
			<thead>
				<tr>
					<th>Product</th>
					<th>Price</th>
					<th>Quantity</th>
					<th>Total</th>
					<th class ="checkStock" style="display: none;">Stock</th>
				</tr>
			</thead>
			<tbody>
				<?php foreach($products as $name => $product): ?>
				<tr>
					<td label="product_name："><?php echo $name; ?></td>
					<td label="unit_price：" class="text-right">$<?php echo $product['unit_price']; ?></td>
					<td label="unit_quantity" class="text-right">
						<input type="number" name="<?php echo $name; ?>unit_quantity" 
						value="<?php echo $product['count']; ?>" min="1" max="25" onchange="updateQuantity('<?php echo $name; ?>', <?php echo $product['unit_price']; ?>)"></td>
					<td label="unit_price" class="text-right" id="<?php echo $name; ?>unit_price">$<?php echo $product['unit_price']*$product['count']; ?></td>
					<td>
						<form action="cart.php" method="post">
						<input type="hidden" name="delete_name" value="<?php echo $name; ?>">
					<button type="submit" class="delete-btn">Delete</button>
					</form>
					</td>
				</tr>
				<?php endforeach; ?>
				<tr class="total">
					<th colspan="3" class="text-center">Total</th>
					<td class="text-right" id="total">$<?php echo $total; ?></td>
				</tr>
			</tbody>
		</table>
		<br>
		<div class="cart-btn">
			<button type="button" class="clear-cart-btn" onclick="clearCart()">Clear Cart</button>
			<button type="button" class="checkout-btn" onclick=" window.open('checkout.php', '_blank')" onsubmit="return validateQuantity();" <?php if(empty($products)) echo 'disabled="disabled"'; ?>>Place An Order</button>
		</div>	
			
	</div>
	<?php endif; ?>

	</body>
</html>	
		