CREATE TABLE `regisrer_directory` (
	`id` int NOT NULL AUTO_INCREMENT,
	`name` varchar(50) NULL,
	`description` varchar(100) NULL,
	`ping_api_path` varchar(255) NULL,
	`version_api_path` varchar(255) NULL,
	`create_date` datetime NOT NULL,
	PRIMARY KEY (`id`) 
);CREATE TABLE `register_node` (	`id` int NOT NULL AUTO_INCREMENT,	`url` varchar(255) NULL,	`ip` varchar(30) NULL,	`description` varchar(100) NULL,	`weight` int NOT NULL,	`status` tinyint NOT NULL,	`create_date` datetime NOT NULL,	`directory_id` int NOT NULL,	PRIMARY KEY (`id`) );CREATE TABLE `register_relation` (	`consumer_id` int NOT NULL,	`consumer_name` varchar(50) NOT NULL,	`provider_id` int NOT NULL,	`provider_name` varchar(50) NOT NULL);