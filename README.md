# FileSaver project 

![image](https://github.com/Darkauron3/FileSaver/assets/75143508/d8772831-39a4-4991-8e51-8dde784571f9)
Login Page

![image](https://github.com/Darkauron3/FileSaver/assets/75143508/eeb93f33-1d9c-4580-bae3-cf2834cc6d57)
Main Page

![image](https://github.com/user-attachments/assets/f7ed3d7e-c388-4e4a-b8ad-745ae780043f)
My Account Page

![image](https://github.com/user-attachments/assets/cbb39980-57d4-4098-9a4e-fa8834ea3fe3)
Admin Tools Page


FileSaver is a project written in C# made especially for Windows operating systems. FileSaver lets users to encrypt and decrypt their personal files of all types with 16 character long password and made by me encryption algorithm. The purpose of this project is making all files containing personal information to be secured in a easy way, so the non so technical users to use it. 

# How to use it
1. Git clone the repository and open the folder in Visual Studio (it may require installing c# libraries)
2. Build it and test it.


# MySQL Server Installation Guide
1. Download MySQL Installer for windows (https://dev.mysql.com/downloads/installer/)
2. After instlling it run it
3. In installation wizard select first options 'Server only' and click Next
4. In the next step MySQL server will be installed click execute button and after its installed click next
5. Click next again in 'Product Configuration' step
6. In Type and Networking step click next 
7. In Authentication Method step click next
8. Now in Accounts and Roles step create root user where in 'MySQL Root Password:' type root and 
in 'Repeat Password:' type root again and click next.
9. In Windows Service step click next
10. In Server File Permissions click next again.
11. In last Apply Configuration step click Execute and after that click finish
12. Then in Porduct Configuration again click next
13. In Installation Complete step click finish

14. Now when we have mysql server installed we need to add dump files to the server and add users.
First in windows search bar find 'MySQL Command Line Client' and open it. Terminal should appear asking 
for password enter 'root' and click enter. Now from here type the following commands in the command line
and after every command click enter:

CREATE DATABASE mydb;
use mydb;
CREATE USER 'normaluser'@'localhost' IDENTIFIED BY 'normalusernormaluser';
CREATE USER 'admin'@'localhost' IDENTIFIED BY 'adminuser1234';
GRANT ALL PRIVILEGES ON mydb.* TO 'admin'@'localhost';
GRANT INSERT, SELECT, UPDATE ON *.* TO 'normaluser'@'localhost';

source C:/fileSaver/sql/mydb_login_logs.sql;
source C:/fileSaver/sql/mydb_user_files.sql;
source C:/fileSaver/sql/mydb_user_files_info.sql;
source C:/fileSaver/sql/mydb_users.sql;
source C:/fileSaver/sql/mydb_users_passwords.sql;
(//HERE ENTER THE PATH TO THE DUMP FILES WHICH ARE LOCATED IN 'sql' FOLDER IN THE 'fileSaver' FOLDER)

15. After databse is all set up, run setup.exe file and use the app.

