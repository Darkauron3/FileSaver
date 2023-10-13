use mydb;
-- Create the Users table
CREATE TABLE Users (
  User_id INT PRIMARY KEY,
  username VARCHAR(255),
  email VARCHAR(255),
  age INT
);

-- Create the Users_passwords table
CREATE TABLE Users_passwords (
  Pass_id INT PRIMARY KEY,
  pass_hash VARCHAR(64),
  salt VARCHAR(32)
);

-- Create the Encryption_keys table
CREATE TABLE Encryption_keys (
  UserKey_en_id INT PRIMARY KEY,
  Key_name VARCHAR(255),
  file_encryptionKey VARBINARY(255)
);

-- Create the Decryption_keys table
CREATE TABLE Decryption_keys (
  Key_de_id INT PRIMARY KEY,
  Key_name VARCHAR(255),
  file_decryptionKey VARBINARY(255)
);

-- Create the Encrypted_Files_info table with foreign key constraints
CREATE TABLE Encrypted_Files_info (
  File_id INT PRIMARY KEY,
  User_id INT,
  File_name VARCHAR(255),
  File_data VARBINARY(255),
  Encryption_key_id INT,
  Is_encrypted BOOLEAN,
  Upload_date DATETIME,
  FOREIGN KEY (User_id) REFERENCES Users(User_id),
  FOREIGN KEY (Encryption_key_id) REFERENCES Encryption_keys(UserKey_en_id)
);

-- Add foreign key constraints for Users_passwords and Decryption_keys
ALTER TABLE Users_passwords
  ADD CONSTRAINT fk_users_passwords
  FOREIGN KEY (Pass_id)
  REFERENCES Users(User_id);

ALTER TABLE Decryption_keys
  ADD CONSTRAINT fk_decryption_keys
  FOREIGN KEY (Key_de_id)
  REFERENCES Users(User_id);
