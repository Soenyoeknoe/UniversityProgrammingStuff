CREATE DATABASE assignment1;
USE assignment1;

-- ----------------------------
-- Table structure for products
-- ----------------------------
DROP TABLE IF EXISTS `products`;
CREATE TABLE `products` (
  `product_id` int(10) unsigned DEFAULT NULL,
  `category_name` varchar(20) DEFAULT NULL,
  `subcategory_name` varchar(20) DEFAULT NULL,
  `product_name` varchar(20) DEFAULT NULL,
  `unit_price` float(8,2) DEFAULT NULL,
  `unit_quantity` varchar(15) DEFAULT NULL,
  `in_stock` int(10) unsigned DEFAULT NULL,
  `prod_description` varchar(255) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of products
-- ----------------------------
BEGIN;
INSERT INTO `products` VALUES (1000, 'frozen', 'Fish Fingers', 'Fish Fingers', 2.55, '500 gram', 1500, 'Premium quality fish fingers, great for parties or gatherings.');
INSERT INTO `products` VALUES (1001, 'frozen', 'Fish Fingers', 'Fish Fingers', 5.00, '1000 gram', 750, 'Premium quality fish fingers, great for parties or gatherings.');
INSERT INTO `products` VALUES (1002, 'frozen', 'Hamburger Patties', 'Hamburger Patties', 2.35, 'Pack 10', 1200, 'Juicy hamburger patties, ready to grill or fry.');
INSERT INTO `products` VALUES (1003, 'frozen', 'Shelled Prawns', 'Shelled Prawns', 6.90, '250 gram', 300, 'Fresh shelled prawns, ideal for seafood dishes.');
INSERT INTO `products` VALUES (1004, 'frozen', 'Tub Ice Cream', 'Tub Ice Cream', 1.80, '1 Litre', 800, 'Indulgent tub ice cream, perfect for dessert lovers.');
INSERT INTO `products` VALUES (1005, 'frozen', 'Tub Ice Cream', 'Tub Ice Cream', 3.40, '2 Litre', 1200, 'Indulgent tub ice cream, perfect for dessert lovers.');
INSERT INTO `products` VALUES (2000, 'health', 'Panadol', 'Panadol', 3.00, 'Pack 24', 2000, 'Long-lasting Panadol tablets, recommended for fever and flu.');
INSERT INTO `products` VALUES (2001, 'health', 'Panadol', 'Panadol', 5.50, 'Bottle 50', 1000, 'Long-lasting Panadol tablets, recommended for fever and flu.');
INSERT INTO `products` VALUES (2002, 'health', 'Bath Soap', 'Bath Soap', 2.60, 'Pack 6', 500, 'Refreshing bath soap bars, leaves your skin feeling clean and rejuvenated.');
INSERT INTO `products` VALUES (2003, 'health', 'Garbage Bags', 'Garbage Bags Small', 1.50, 'Pack 10', 500, 'Durable garbage bags, suitable for disposing of bulky items.');
INSERT INTO `products` VALUES (2004, 'health', 'Garbage Bags', 'Garbage Bags Large', 5.00, 'Pack 50', 300, 'Durable garbage bags, suitable for disposing of bulky items.');
INSERT INTO `products` VALUES (2005, 'health', 'Washing Powder', 'Washing Powder', 4.00, '1000 gram', 800, 'High-quality washing powder, ensures clean and fresh laundry.');
INSERT INTO `products` VALUES (3000, 'fresh', 'Cheddar Cheese', 'Cheddar Cheese', 8.00, '500 gram', 1000, 'Premium quality cheddar cheese, great for cooking or snacking.');
INSERT INTO `products` VALUES (3001, 'fresh', 'Cheddar Cheese', 'Cheddar Cheese', 15.00, '1000 gram', 1000, 'Premium quality cheddar cheese, great for cooking or snacking.');
INSERT INTO `products` VALUES (3002, 'fresh', 'T Bone Steak', 'T Bone Steak', 7.00, '1000 gram', 200, 'Juicy T-bone steak, ideal for grilling or frying.');
INSERT INTO `products` VALUES (3003, 'fresh', 'Navel Oranges', 'Navel Oranges', 3.99, 'Bag 20', 200, 'Fresh navel oranges, packed with vitamins and perfect for juicing.');
INSERT INTO `products` VALUES (3004, 'fresh', 'Bananas', 'Bananas', 1.49, 'Kilo', 400, 'Ripe bananas, a healthy and convenient snack.');
INSERT INTO `products` VALUES (3005, 'fresh', 'Peaches', 'Peaches', 2.99, 'Kilo', 500, 'Sweet and juicy peaches, great for desserts or eating fresh.');
INSERT INTO `products` VALUES (3006, 'fresh', 'Grapes', 'Grapes', 3.50, 'Kilo', 200, 'Fresh grapes, perfect for snacking or adding to fruit salads.');
INSERT INTO `products` VALUES (3007, 'fresh', 'Apples', 'Apples', 1.99, 'Kilo', 500, 'Crisp and flavorful apples, a healthy and delicious snack.');
INSERT INTO `products` VALUES (4000, 'beverage', 'Earl Grey Tea Bags', 'Earl Grey Tea Bags', 2.49, 'Pack 25', 1200, 'Classic Earl Grey tea bags, aromatic and refreshing.');
INSERT INTO `products` VALUES (4001, 'beverage', 'Earl Grey Tea Bags', 'Earl Grey Tea Bags', 7.25, 'Pack 100', 1200, 'Classic Earl Grey tea bags, aromatic and refreshing.');
INSERT INTO `products` VALUES (4002, 'beverage', 'Earl Grey Tea Bags', 'Earl Grey Tea Bags', 13.00, 'Pack 200', 800, 'Classic Earl Grey tea bags, aromatic and refreshing.');
INSERT INTO `products` VALUES (4003, 'beverage', 'Instant Coffee', 'Instant Coffee', 2.89, '200 gram', 500, 'Rich and aromatic instant coffee, easy to prepare and enjoy.');
INSERT INTO `products` VALUES (4004, 'beverage', 'Instant Coffee', 'Instant Coffee', 5.10, '500 gram', 500, 'Rich and aromatic instant coffee, easy to prepare and enjoy.');
INSERT INTO `products` VALUES (4005, 'beverage', 'Chocolate Bar', 'Chocolate Bar', 2.50, '500 gram', 300, 'Indulgent chocolate bar, smooth and delicious.');
INSERT INTO `products` VALUES (5000, 'pet', 'Dry Dog Food', 'Dry Dog Food', 5.95, '5 kg Pack', 400, 'Nutritious dry dog food, formulated to support your dog’s health and vitality.');
INSERT INTO `products` VALUES (5001, 'pet', 'Dry Dog Food', 'Dry Dog Food', 1.95, '1 kg Pack', 400, 'Nutritious dry dog food, formulated to support your dog’s health and vitality.');
INSERT INTO `products` VALUES (5002, 'pet', 'Bird Food', 'Bird Food', 3.99, '500g packet', 200, 'High-quality bird food, packed with essential nutrients for your feathered friends.');
INSERT INTO `products` VALUES (5003, 'pet', 'Cat Food', 'Cat Food', 2.00, '500g tin', 200, 'Wholesome cat food, specially formulated to meet the dietary needs of cats.');
INSERT INTO `products` VALUES (5004, 'pet', 'Fish Food', 'Fish Food', 3.00, '500g packet', 200, 'Nutritious fish food, ideal for all types of aquarium fish.');
INSERT INTO `products` VALUES (2006, 'health', 'Laundry Bleach', 'Laundry Bleach', 3.55, '2 Litre Bottle', 500, 'Powerful laundry bleach, effectively removes stains and brightens whites.');
COMMIT;
