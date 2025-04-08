CREATE DATABASE assignment2;
USE assignment2;

-- ----------------------------
-- Table structure for orders
-- ----------------------------
DROP TABLE IF EXISTS `orders`;
CREATE TABLE `orders` (
  `order_id` INT AUTO_INCREMENT PRIMARY KEY,
  `user_email` VARCHAR(50) NOT NULL,
  `user_mobile` VARCHAR(20) NOT NULL,
  `car_model` VARCHAR(50) NOT NULL,
  `rent_start_date` DATE NOT NULL,
  `rent_end_date` DATE NOT NULL,
  `quantity` INT UNSIGNED NOT NULL,
  `price` FLOAT(8,2) NOT NULL,
  `status` ENUM('unconfirmed', 'confirmed') NOT NULL DEFAULT 'unconfirmed'
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4;

