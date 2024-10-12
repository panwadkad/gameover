CREATE TABLE `BookHeader` (
  `book_call_no` varchar(15) PRIMARY KEY,
  `title` varchar(60),
  `anthor` varchar(40),
  `language` varchar(15),
  `edition` varchar(3),
  `ISBN` varchar(13),
  `publisher` varchar(40),
  `print_year` varchar(4),
  `book_page` int,
  `book_price` int,
  `received_date` date,
  `book_source` varchar(1),
  `classification` varchar(3)
);

CREATE TABLE `Book` (
  `barcode` varchar(10) PRIMARY KEY,
  `book_call_no` varchar(15),
  `book_regis_id` varchar(15),
  `copy` varchar(2),
  `status` varchar(255),
  `member_code` varchar(8)
);

CREATE TABLE `Member` (
  `member_code` varchar(8) PRIMARY KEY,
  `name` varchar(40),
  `address` varchar(80),
  `phone` varchar(30),
  `member_type` varchar(1),
  `borrow_amount` int,
  `day_amount` int
);

CREATE TABLE `MemberTRN` (
  `member_code` varchar(8) PRIMARY KEY,
  `contract_date` date,
  `item_type` varchar(1),
  `valid_date` date,
  `expire_date` date,
  `description` longtext,
  `charge` int
);

CREATE TABLE `ServiceTRN` (
  `member_code` varchar(8) PRIMARY KEY,
  `barcode` varchar(12),
  `borrow_date` date,
  `due_date` date,
  `return_date` date,
  `delay_day` int,
  `charge` int
);

ALTER TABLE `BookHeader` ADD FOREIGN KEY (`book_call_no`) REFERENCES `Book` (`book_call_no`);

ALTER TABLE `Member` ADD FOREIGN KEY (`member_code`) REFERENCES `Book` (`member_code`);

ALTER TABLE `Member` ADD FOREIGN KEY (`member_code`) REFERENCES `MemberTRN` (`member_code`);

ALTER TABLE `Member` ADD FOREIGN KEY (`member_code`) REFERENCES `ServiceTRN` (`member_code`);

ALTER TABLE `Book` ADD FOREIGN KEY (`barcode`) REFERENCES `ServiceTRN` (`barcode`);
