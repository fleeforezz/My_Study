# 🎯 Level-Up Project: Mini E-Commerce Console App

🚀 Let’s level up our console project. The next step is to add more real-world features and complexity so you practice OOP, design patterns, and data handling.

### 📦 Features to Add
1. Entities
    + Product (Id, Name, Price, Stock)
    + Customer (Id, Name, Email)
    + Order (Id, CustomerId, List of Products, TotalPrice, CreatedAt)

2. Repositories
    + ProductRepository
    + CustomerRepository
    + OrderRepository

3. Features
    + Add, list, update, and delete products
    + Register customers
    + Place an order (decrease product stock automatically)
    + Show order history for a customer
    + Persist all data into JSON files (products.json, customers.json, orders.json)

4. Improvements
    + Use int IDs (auto-increment)
    + Use repository pattern for clean separation
    + Display menus and sub-menus
    + Validation (e.g., cannot order if stock is insufficient)

# 📂 Project Structure
```
MiniECommerce/
│── Program.cs
│── Models/
│    ├── Product.cs
│    ├── Customer.cs
│    └── Order.cs
│── Data/
│    └── FileDatabase.cs
│── Repositories/
│    ├── IRepository.cs
│    ├── ProductRepository.cs
│    ├── CustomerRepository.cs
│    └── OrderRepository.cs
```