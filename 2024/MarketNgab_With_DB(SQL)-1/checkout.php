<?php
session_start();
// Connect to the database
$connection = mysqli_connect('awseb-e-isdrgcrqu3-stack-awsebrdsdatabase-ezaonabyn2pg.cbeu2m0uuauu.us-east-1.rds.amazonaws.com', 'uts', 'utsuts123', 'assignment1');

// Check connection
if (mysqli_connect_errno()) {
    echo "Failed to connect to MySQL: " . mysqli_connect_error();
    exit;
}

function updateStock() {
    global $connection; // Access the global database connection

    // Retrieve the products from the session
    $products = isset($_SESSION['products']) ? $_SESSION['products'] : [];
	$quantity = isset($_SESSION['unit_quantity']) ? $_SESSION['unit_quantity'] : [];
    
	foreach ($products as $productName => $product) {
        $count = $product['count'];

        // Query the database to get the current in_stock value
        $query = "SELECT in_stock FROM products WHERE product_name = '$productName'";
        $result = mysqli_query($connection, $query);

        if ($result && mysqli_num_rows($result) > 0) {
            $row = mysqli_fetch_assoc($result);
            $currentStock = $row['in_stock'];

            // Calculate the new stock value
            $newStock = max(0, $currentStock - $count);

            // Update the in_stock value in the database
            $updateQuery = "UPDATE products SET in_stock = $newStock WHERE product_name = '$productName'";
            mysqli_query($connection, $updateQuery);
        }
    }

    // Clear the cart after updating the stock
    unset($_SESSION['products']);
}

// Call the updateStock function
updateStock();
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
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.bundle.min.js"crossorigin="anonymous"></script>
		<style>
			#submitBtn:disabled:hover {
				cursor: not-allowed;
			}
		</style>
		<script>
			function validateForm() {
				var name = document.forms["orderForm"]["name"].value;
				var address = document.forms["orderForm"]["address"].value;
				var suburb = document.forms["orderForm"]["suburb"].value;
				var state = document.forms["orderForm"]["state"].value;
				var country = document.forms["orderForm"]["country"].value;
				var mobileNumber=document.forms["orderForm"]["mobileNumber"].value;
				var email = document.forms["orderForm"]["email"].value;
				var mobileRegex =/^(?:\+?61|0)[1-9](?: ?\d){8}$/;
				var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; // email regular expression
				if (name == "" || address == "" || suburb == "" || state == "" || country == "" || email == "" || mobileNumber == "") {
					alert("Please fill out all required fields");
					return false;
				}
				else if (!emailRegex.test(email)) { // check if email is in valid format
					alert("Please enter a valid email address");
					return false;
				}
				else if (!mobileRegex.test(mobileNumber)) {
					alert ("Please enter a valid mobile");
					return false;
				}
				
			}
			// Function to enable/disable submit button
			function checkFormValidity() {
					var inputs = document.querySelectorAll('input[type="text"], select');
					var valid = true;

					inputs.forEach(function(input) {
						if (input.value.trim() === '') {
							valid = false;
						}
					});

					var submitButton = document.getElementById("submitBtn");
					submitButton.disabled = !valid;
				}

				// Add event listeners to inputs for checking validity
				document.addEventListener('DOMContentLoaded', function() {
					var inputs = document.querySelectorAll('input[type="text"], select');

					inputs.forEach(function(input) {
						input.addEventListener('input', checkFormValidity);
					});
				});
		</script>

</head>
    
<body>
    <section class="all">
      <!-- Navbar -->
      <nav id="navbar">
        <div class="navbar__logo">
		<a href="index.php"><img src="image/logo.png" width="50" height="50"></a>
        </div>

        <!-- search bar -->
        <!--<div class="navbar__search">
          <form id="search-form">
            <div class="searchbar">
              
              <input
                type="search"
                id="mySearch"
                name="q"
                placeholder="Search the site…" />
              <button class="search-button">Search</button>
            </div>
          </form>
        </div>-->
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
			<h1>Delivery Details</h1>
			<div id="productReadyMessage" style="display: none; color: green;">Your product is ready to order.</div>
				<form name="orderForm" action="processOrder.php" onsubmit="updateStock(); return validateForm()" method="post">
					<table>
						<tr>
							<td class="checkout-text">Name<span style="color:red">*</span></td>
							<td><input type="text" name="name" oninput="checkFormValidity()"></td>
						</tr>
						<tr>
							<td class="checkout-text">Email<span style="color:red">*</span></td>
							<td><input type="text" name="email" oninput="checkFormValidity()"></td>
						</tr>
						<tr>
							<td class="checkout-text">Mobile Number<span style="color:red">*</span></td>
							<td><input type="text" name="mobileNumber" oninput="checkFormValidity()"></td>
						</tr>
						<tr>
							<td class="checkout-text">Address<span style="color:red">*</span></td>
							<td><input type="text" name="address" oninput="checkFormValidity()"></td>
						</tr>
						<tr>
							<td class="checkout-text">Suburb<span style="color:red">*</span></td>
							<td><input type="text" name="suburb" oninput="checkFormValidity()"></td>
						</tr>
						<tr>
							<td class="checkout-text">State<span style="color:red">*</span></td>
							<td>
								<select name="state" oninput="checkFormValidity()">
									<option value="NSW">New South Wales (NSW)</option>
									<option value="VIC">Victoria (VIC)</option>
									<option value="QLD">Queensland (QLD)</option>
									<option value="WA">Western Australia (WA)</option>
									<option value="SA">South Australia (SA)</option>
									<option value="TAS">Tasmania (TAS)</option>
									<option value="ACT">Australian Capital Territory (ACT)</option>
									<option value="NT">Northern Territory (NT)</option>
									<option value="Others">Others</option>
								</select>
							</td>
						</tr>
						<tr>
							<td class="checkout-text">Country<span style="color:red">*</span></td>
							<td><input type="text" name="country"></td>
						</tr>

					</table>
					<br>
					<input id="submitBtn" type="submit" value="Place Order" onsubmit="return validateForm()" disabled>
				</form>
			</div>
        </div>
	  </section>
	</section>
	<div class="cart-toggle">
		<button id="toggleCartBtn">Show Cart</button>
	</div>  
	<section id="cart">
		<iframe name="view" src="cart.php" frameborder=0 width="100%" height="100%"></iframe>
	</section>

	<script>
        const cartSection = document.getElementById('cart');
        const toggleCartBtn = document.getElementById('toggleCartBtn');

        toggleCartBtn.addEventListener('click', function() {
            if (cartSection.style.display === 'none') {
                cartSection.style.display = 'flex';
                toggleCartBtn.textContent = "X";
            } else {
                cartSection.style.display = 'none';
                toggleCartBtn.textContent = 'Show Cart';
            }
        });
		
		window.addEventListener('load', function() {
			const cartIframe = document.querySelector('iframe[name="view"]');
			const cartBtnDiv = cartIframe.contentWindow.document.querySelector('.cart-btn');
			const deleteBtnRemoval = cartIframe.contentWindow.document.querySelector('.delete-btn');
			const productReadyMessage = document.getElementById('productReadyMessage');
			const cartTable = cartIframe.contentWindow.document.querySelector('table');
			if (cartBtnDiv) {
				cartBtnDiv.style.display = 'none';
				const tableRows = cartTable.querySelectorAll('tr');
				
					tableRows.forEach(row => {
						const lastCell = row.lastElementChild;
						if (lastCell.textContent.trim() === 'Delete') {
							lastCell.textContent = 'In Stock';
						}
					});
				productReadyMessage.style.display = 'block';
			}
		});
		

    </script>

</body>
</html>