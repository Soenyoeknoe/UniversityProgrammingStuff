
// Item filter
const sidemenuContainer = document.querySelector('.side__menu');
const mainmenuContainer = document.querySelector('.main__menu');
const mainBtnContainer = document.querySelector('.product__category');
const productContainer = document.querySelector('.main__top-level');
const products = document.querySelectorAll('.product');

sidemenuContainer.addEventListener('click', (e) => {
    const filter = e.target.dataset.filter
    if (filter == null) {
        return;
    }
    products.forEach((product) => {
        console.log(product.dataset.type);
        if (filter === product.dataset.type) {
            product.classList.remove('invisible');
        } else {
            product.classList.add('invisible');
        }
    });
});

mainmenuContainer.addEventListener('click', (e) => {
    const filter = e.target.dataset.filter
    if (filter == null) {
        return;
    }
    products.forEach((product) => {
        console.log(product.dataset.type);
        if (filter === product.dataset.type) {
            product.classList.remove('invisible');
        } else {
            product.classList.add('invisible');
        }
    });
});






// not working
// add item to cart
function addItemToCart() {
    
    var itemName = document.getElementById("item-name").innerHTML;
    var itemPrice = document.getElementById("item-price").innerHTML;
    var itemQuantity = document.getElementById("item-quantity").value;
    
    // Add item to shopping cart
    var cartItem = { name: itemName, price: itemPrice, quantity: itemQuantity };
    var cart = JSON.parse(localStorage.getItem("cart")) || [];
    cart.push(cartItem);
    localStorage.setItem("cart", JSON.stringify(cart));
  }



  const addButton = document.querySelectorAll('.add-item');
  addButton.forEach(btn => {
    btn.addEventListener('click', (e) => {
      e.preventDefault();
      const productId = btn.getAttribute('href').split('=')[1];
      window.location.href = `item_details.php?id=${productId}`;
    });
  });

// not working
// When Side bar top menu clicked, Open the second level menu  
const navbarToggleBtn = document.querySelector('.category-btn.has-subcategories');
const secondMenu = document.querySelector('.subcategories');
navbarToggleBtn.addEventListener('click', ()=> {
    secondMenu.classList.add('open');
});
//   sidebar

document.addEventListener("DOMContentLoaded", function(){
    document.querySelectorAll('.sidebar .nav-link').forEach(function(element){
      
      element.addEventListener('click', function (e) {
  
        let nextEl = element.nextElementSibling;
        let parentEl  = element.parentElement;	
        let caretIcon = element.querySelector('.bi-caret-down-fill');
  
          if(nextEl) {
              e.preventDefault();	
              let mycollapse = new bootstrap.Collapse(nextEl);
              
              if(nextEl.classList.contains('show')){
                mycollapse.hide();
                
              } else {
                  mycollapse.show();
                  
                  // find other submenus with class=show
                  var opened_submenu = parentEl.parentElement.querySelector('.submenu.show');
                  // if it exists, then close all of them
                  if(opened_submenu){
                    new bootstrap.Collapse(opened_submenu);
                  }
              }
          }
      }); // addEventListener
    }) // forEach
  }); 


