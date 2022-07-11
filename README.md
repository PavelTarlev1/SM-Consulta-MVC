# SM-Consulta-MVC
Assignment-SM Consulta

To develop an Application for calculating net salary. 

**The application must work with the following rules:**
1. Taxes for salary less than or equal to the minimum threshold of BGN 1000 are not charged.
2. Total income tax of 10% for salary above the minimum threshold.
3. Health and social insurance of 15% for an amount greater than the minimum threshold, with the maximum insurance threshold being BGN 3,000.
4. The parameters must be maintained on an annual basis, i.e. they can be different for each year.

**Application should**
* [x] The application must be web based on one of the following technologies (MVC Core, Razor or Blazor)
* [x] To maintain a database of employees and their salaries.
* [x] The application should be able to calculate net salary based on the entered gross salary.
* [x] All parameters involved in the calculations can be saved in the database and used repeatedly.

**Guide how to set up the application**

1. In order to use code-based migration, you need to execute the following commands in the Package Manager Console in Visual Studio: Enable-Migrations: Enables the migration in your project by creating a Configuration class.
2. Update-Database: Executes the last migration file created by the Add-Migration command and applies changes to the database schema.



