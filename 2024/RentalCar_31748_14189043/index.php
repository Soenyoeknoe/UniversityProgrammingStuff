<?php
$jsonData = file_get_contents('cars.json');
$cars = json_decode($jsonData, true);
?>
<script>
  
  document.querySelector('.search-button').addEventListener('click', function(event) {
    event.preventDefault();
    
    const searchInput = document.querySelector('#mySearch');
    const searchTerm = searchInput.value;
    
    const xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function() {
      if (xhr.readyState === XMLHttpRequest.DONE) {
        if (xhr.status === 200) {
          const productsContainer = document.querySelector('#products');
          productsContainer.innerHTML = xhr.responseText;
        } else {
          console.error('Error: ' + xhr.status);
        }
      }
    };
    xhr.open('GET', 'search.php?q=' + searchTerm);
    xhr.send();
  });
  
</script>

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
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.bundle.min.js"crossorigin="anonymous"></script>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.0/font/bootstrap-icons.css">
        <Style>
          .hints-box {
            position: absolute;
            display: flex;
            top: 55%; /* Position the hints box right below the search box */
            left: 87.5%;
            z-index: 100; /* A higher z-index value to make it appear in front of other elements */
            background-color: #fff;
            border: 1px solid #ccc;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.2);
            max-height: 200px; /* Set a maximum height for the hints box */
            overflow-y: auto; /* Enable vertical scrolling if the hints exceed the maximum height */
            width: 9%; /* Set the width of the hints box to match the search box */
            
          }
          
          .hints-box div {
            padding: 8px 12px;
            cursor: pointer;
            color: #000;
          }
          
          .hints-box div:hover {
            background-color: #f1f1f1;
            color:#000;
          } 
          .hints-box .recent-heading {
            font-size: 12px;
            font-weight: bold;
            background-color: #fff;
            padding: 8px 12px;
            color: #333;
            cursor: default;
          }
          .hints-box .recent-heading:hover {
            font-size: 12px;
            font-weight: bold;
            background-color: #fff;
            padding: 8px 12px;
            color: #333;
            cursor: default;
          }
          .nav-link:hover {
            font-size: 24px;
            color: #333;
          }
          .nav-link {
            color: white;
            text-decoration: none;
          }
          .prod-browse {
            color: white;
            text-decoration: none;
            font-size: 16px;
          }
          .prod-browse:hover {
            color: #333;
            font-size: 18px;
          }
          .product__item:hover {
            transform: scale(1.05);
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
          }
          button.add-item.disabled {
            background-color: grey;
            cursor: not-allowed;
          }
          #mySearch:focus {
            border-color: #333;
            box-shadow: 0 0 5px rgba(51, 51, 51, 0.5);
          }
          .searchbar {
            display: flex;
            height: 35px;
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
        </Style>
      </head>
    
    <body>
    <section class="all">
      <!-- Navbar -->
      <nav id="navbar">
        <div class="navbar__logo">
          <a href="index.php"><img src="image/logo.png" width="106" height="60"></a>
        </div>
        
        <!-- search bar -->
        <div class="navbar__search">
          <form id="search-form">
            <div class="searchbar">
              <div class="navbar__navigator">
                <div>&nbsp;<a class="navigator" href="" id="reserveLink">Reserve a Car</a> &nbsp;</div>
              </div>
              <input
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
            <div id="hints-box" class="hints-box" style="display: none;"></div>
          </form>
        </div>
        
      </nav>
      
      
      <!-- container -->
      <section class="main__view">
        <!-- Side bar -->  
        <section id="side">
          <!-- Navbar top level menu -->
            <div class="side__menu">
              
              <nav class="sidebar card py-2 mb-10" style="background-color: #a6b59e;">
                <ul class="nav flex-column" id="nav_accordion">
                  <a class="prod-browse" data-bs-toggle="collapse" data-bs-target="#carCategories">&nbsp;
                    <svg width="20px" height="20px" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" transform="rotate(180)">
                      <g id="SVGRepo_bgCarrier" stroke-width="0"></g>
                      <g id="SVGRepo_tracerCarrier" stroke-linecap="round" stroke-linejoin="round"></g>
                      <g id="SVGRepo_iconCarrier"> 
                        <path d="M4 18L20 18" stroke="#ffffff" stroke-width="2" stroke-linecap="round"></path> 
                        <path d="M4 12L20 12" stroke="#ffffff" stroke-width="2" stroke-linecap="round"></path> 
                        <path d="M4 6L20 6" stroke="#ffffff" stroke-width="2" stroke-linecap="round"></path> 
                      </g>
                    </svg> Browse Product &nbsp;
                  </a>
                  <ul class="collapse" id="carCategories">
                    <li class="nav-item">
                      <a class="nav-link" href="index.php"> All </a>
                    </li>
                    <li class="nav-item has-submenu">
                      <a class="nav-link" href="#" data-bs-toggle="collapse" data-bs-target="#typeSubmenu"> Type <i class="bi small bi-caret-down-fill"></i> </a>
                      <?php foreach (array_unique(array_column($cars['cars'], 'type')) as $type): ?>
                      <ul class="collapse submenu"  id="typeSubmenu">
                        <li><a class="nav-link" href="#" data-model="<?php echo $type; ?>"><?php echo $type; ?> </a></li>
                      </ul>
                      <?php endforeach; ?>
                    </li>
                    <li class="nav-item has-submenu">
                      <a class="nav-link" href="#" data-bs-toggle="collapse" data-bs-target="#brandSubmenu"> Brand <i class="bi small bi-caret-down-fill"></i> </a>
                      <?php foreach (array_unique(array_column($cars['cars'], 'brand')) as $brand): ?>
                      <ul class="collapse submenu" id="brandSubmenu">
                        <li><a class="nav-link" href="#" data-model="<?php echo $brand; ?>"><?php echo $brand; ?> </a></li>
                      </ul>
                      <?php endforeach; ?>
                    </li>
                  </ul>
                </ul>
                </nav>
            </div>          
        </section>

        <!-- Main -->
        <section id="main">
          <div class="section__container">
          <div class="main__top-level" id="car-grid">
            <!-- Car grid will be populated here -->
          </div>
          </div>
        </section>
        
        <!-- Product Detail -->
        <section id="detail">
          <iframe name="view" src="item_details.php" frameborder=0 width="100%" height="100%"></iframe>
        </section>

      <!-- Shopping Cart -->   
      <div class="cart-toggle">
          <button id="toggleCartBtn">Check Order</button>
      </div>  
      <section id="cart">
        <iframe name="view" src="cart.php" frameborder=0 width="100%" height="100%"></iframe>
      </section>  
    </section>
    <script>
      const carCategories = document.getElementById('carCategories');

        const typeBrandLinks = document.querySelectorAll('#typeSubmenu .nav-link, #brandSubmenu .nav-link');
        typeBrandLinks.forEach(link => {
          link.addEventListener('click', () => {
            const collapse = new bootstrap.Collapse(carCategories, { toggle: false });
            collapse.hide();
          });
        });
        const reserveLink = document.getElementById('reserveLink');
        const lastRentedCarId = localStorage.getItem('lastRentedCarId');

        if (lastRentedCarId) {
          reserveLink.href = `reservation.php?id=${lastRentedCarId}`;
        } else {
          reserveLink.href = 'reservation.php';
        }
        const cartSection = document.getElementById('cart');
        const toggleCartBtn = document.getElementById('toggleCartBtn');

        toggleCartBtn.addEventListener('click', function() {
            if (cartSection.style.display === 'none') {
                cartSection.style.display = 'flex';
                toggleCartBtn.textContent = "X";
            } else {
                cartSection.style.display = 'none';
                toggleCartBtn.textContent = 'Check Order';
            }
        });
        
        
        const searchInput = document.getElementById('mySearch');
        const hintsBox = document.getElementById('hints-box');
        const carGrid = document.getElementById('car-grid');
        const recentSearches = JSON.parse(localStorage.getItem('recentSearches')) || [];
      
        function showHints(searchTerm) {
          hintsBox.innerHTML = '';
          const fragment = document.createDocumentFragment();
          const cars = <?php echo json_encode($cars['cars']); ?>;
          
          if (searchTerm.trim() !== '') {
            let count = 0;
            const matchedCars = cars.filter(car => {
              const carDetails = `${car.brand} ${car.model} ${car.type}`.toLowerCase();
              return carDetails.includes(searchTerm.toLowerCase());
            });
            const heading = document.createElement('div');
            heading.textContent = 'Suggestions';
            heading.classList.add('recent-heading');
            fragment.appendChild(heading);
            matchedCars.forEach(car => {
              if (count < 3) {
                const hint = document.createElement('div');
                const carDetails = `${car.brand} ${car.model}`.toLowerCase();
                const boldText = carDetails.replace(searchTerm.toLowerCase(), match => `<strong>${match}</strong>`);
                hint.innerHTML = boldText;
                fragment.appendChild(hint);
                count++;
              }
            });
          } else {
            // If search box is empty, show first three products
            for (let i = 0; i < 3; i++) {
              const hint = document.createElement('div');
              hint.textContent = `${cars[i].brand} ${cars[i].model}`;
              fragment.appendChild(hint);
            }
          }

          hintsBox.appendChild(fragment);
          
          // Add event listeners to the hint elements after appending to the DOM
          const hintElements = hintsBox.querySelectorAll('div:not(.recent-heading)');
          hintElements.forEach(hintElement => {
            hintElement.addEventListener('click', function() {
              searchInput.value = this.textContent;
              filterCars(searchInput.value);
              hintsBox.style.display = 'none';
            });
          });
        }
        searchInput.addEventListener('focus', function() {
          if (this.value.trim() === '') {
            showRecentSearches();
          } else {
            showHints(this.value);
          }
        });

        searchInput.addEventListener('keyup', function() {
          showHints(this.value);
        });
        
        searchInput.addEventListener('input', function() {
          if(this.value === ''){
            hintsBox.style.display = 'none';
            showHints(this.value);
          }
          else {
            hintsBox.style.display = 'block';
            showHints(this.value);
          }
        });

        function hideHints() {
          hintsBox.style.display = 'none';
        }

        function showRecentSearches() {
          hintsBox.innerHTML = '';
          const fragment = document.createDocumentFragment();

          if (recentSearches.length > 0) {
            const heading = document.createElement('div');
            heading.textContent = 'Recent Searches';
            heading.classList.add('recent-heading');
            fragment.appendChild(heading);

            recentSearches.slice(0, 3).forEach(search => {
              const hint = document.createElement('div');
              if (search !== "") {
                hint.textContent = search;
                fragment.appendChild(hint);
                
                hint.addEventListener('click', function() {
                  searchInput.value = this.textContent;
                  filterCars(searchInput.value);
                  hintsBox.style.display = 'none';
                  
                });
              }
            });
            
            hintsBox.appendChild(fragment);
            hintsBox.style.display = 'block';
          } 
        }

        function filterCars(searchTerm) {
          const cars = <?php echo json_encode($cars['cars']); ?>;
          const filteredCars = cars.filter(car => {
            const carDetails = `${car.brand} ${car.model} ${car.type}`.toLowerCase();
            return carDetails.includes(searchTerm.toLowerCase());
          });

          carGrid.innerHTML = '';
          const fragment = document.createDocumentFragment();

          filteredCars.forEach(car => {
            const carItem = document.createElement('div');
            carItem.classList.add('product__item');

            const carImage = document.createElement('img');
            carImage.classList.add('product__img');
            carImage.src = car.image;
            carImage.alt = `${car.brand} ${car.model}`;

            const carMenu = document.createElement('div');
            carMenu.classList.add('product__menu');

            const carTitle = document.createElement('h4');
            carTitle.classList.add('card-title');
            carTitle.textContent = `${car.brand} ${car.model} ${car.model_year}`;

            const carPrice = document.createElement('p');
            carPrice.classList.add('card-price');
            carPrice.textContent = `$${car.pricePerDay}/day`;

            const carDescription = document.createElement('p');
            carDescription.classList.add('card-text');
            carDescription.textContent = car.description;

            const carMileage = document.createElement('p');
            carMileage.classList.add('card-text');
            carMileage.textContent = `Mileage: ${car.mileage}`;

            const carFuelType = document.createElement('p');
            carFuelType.classList.add('card-text');
            carFuelType.textContent = `Fuel Type: ${car.fuelType}`;

            const carSeats = document.createElement('p');
            carSeats.classList.add('card-text');
            carSeats.textContent = `Seats: ${car.seats}`;

            const carQuantity = document.createElement('p');
            carQuantity.classList.add('card-text');
            carQuantity.textContent = `${car.quantity} car available`;

            const rentButton = document.createElement('button');
            rentButton.classList.add('add-item');
            rentButton.textContent = 'Rent';
            rentButton.disabled = car.quantity === 0;
            if (rentButton.disabled) {
            rentButton.classList.add('disabled');
            } else {
                rentButton.addEventListener('click', () => {
                  window.location.href = `reservation.php?id=${car.id}`;
                  updateLastRentedCarId(car.id);
                });
            }

            carMenu.appendChild(carTitle);
            carMenu.appendChild(carPrice);
            carMenu.appendChild(carDescription);
            carMenu.appendChild(carMileage);
            carMenu.appendChild(carFuelType);
            carMenu.appendChild(carSeats);
            carMenu.appendChild(carQuantity);
            carMenu.appendChild(rentButton);

            carItem.appendChild(carImage);
            carItem.appendChild(carMenu);

            fragment.appendChild(carItem);
          });

          carGrid.appendChild(fragment);

          // Update recent searches
          const searchIndex = recentSearches.indexOf(searchTerm);
          if (searchIndex !== -1) {
            recentSearches.splice(searchIndex, 1);
          }
          recentSearches.unshift(searchTerm);
          recentSearches.splice(3);
          localStorage.setItem('recentSearches', JSON.stringify(recentSearches));
        }

        function updateLastRentedCarId(carId) {
          localStorage.setItem('lastRentedCarId', carId);
          const reserveLink = document.querySelector('.navigator[href^="reservation.php"]');
          if (reserveLink) {
            reserveLink.href = `reservation.php?id=${carId}`;
          }
        }
        // Event listeners
        searchInput.addEventListener('keyup', function() {
          showHints(this.value);
        });

        searchInput.addEventListener('blur', function() {
          hideHints();
        });

        searchInput.addEventListener('focus', function() {
          showRecentSearches();
        });

        const searchForm = document.getElementById('search-form');
        searchForm.addEventListener('submit', function(event) {
          event.preventDefault();
          filterCars(searchInput.value);
        });

        // Add click event listeners to category links
        const categoryLinks = document.querySelectorAll('.nav-link[data-model]');
        categoryLinks.forEach(link => {
          link.addEventListener('click', function() {
            const model = this.getAttribute('data-model');
            searchInput.value = model;
            filterCars(model);
          });
        });

        // Initial load
        filterCars('');
       
    </script>
    </body>
</html>