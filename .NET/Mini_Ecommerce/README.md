# 🎯 Level-Up Project: Mini E-Commerce Console App

## Level 1
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

### 📂 Project Structure
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
## Level 2
Right now your project is a basic CRUD console app with a repository pattern and file persistence. We can “level it up” step by step into a more realistic mini e-commerce system.

### 🛒 Level-Up Features
#### 1. Entities & Relationships
    + Product (already have)
    + Customer (Id, Name, Email, Address)
    + Order (Id, CustomerId, Date, List of OrderItems, TotalAmount)
    + OrderItem (ProductId, Quantity, PriceAtPurchase)

This introduces relationships (one-to-many between Order and OrderItems).

#### 2. Repository Expansion
+ IRepository<T> stays generic.
+ Repositories:
    + ProductRepository (done ✅)
    + CustomerRepository
    + OrderRepository (with ability to add new orders and load all customer orders).

#### 3. Features for the Console App

1. Product Management
    + Add, update, delete, list.
2. Customer Management
    + Register new customers.
    + View customers.
3. Order Management
    + Place an order (choose a customer, add products with quantity).
    + Show order history for a customer.
    + Calculate totals.
4. Search
    + Find products by name or price range.
5. Reports
    + Total revenue.
    + Best-selling products.

## Level 3
Adding a Service Layer is exactly the next big step.
It makes your project more clean, scalable, and testable because:

+ Repositories = raw data access (CRUD, persistence to local file).
+ Services = business logic (validation, calculations, rules).
+ Program/UI = only user interaction.

### 🔑 Updated Architecture
```
ECommerceApp/
│
├── Models/
│   ├── Product.cs
│   ├── Customer.cs
│   ├── Order.cs
│   └── OrderItem.cs
│
├── Repositories/
│   ├── IRepository.cs
│   ├── ProductRepository.cs
│   ├── CustomerRepository.cs
│   └── OrderRepository.cs
│
├── Services/
│   ├── ProductService.cs
│   ├── CustomerService.cs
│   └── OrderService.cs
│
├── Database/
│   └── FileDatabase.cs   (JSON local storage)
│
└── Program.cs
```

## Level 4
You’re moving from a simple 3-layer structure to Domain-Driven Design (DDD). That means instead of just Models, Repositories, and Services, you’ll start thinking in terms of Domain, Application, Infrastructure, and UI layers.

Here’s how you can restructure your mini e-commerce project to align with DDD principles:
```
ECommerceApp/
│
├── Domain/                      # Core business logic (Entities, Value Objects, Aggregates, Interfaces)
│   ├── Entities/
│   │   ├── Product.cs
│   │   ├── Customer.cs
│   │   ├── Order.cs
│   │   └── OrderItem.cs
│   │
│   ├── ValueObjects/
│   │   ├── Address.cs
│   │   └── Money.cs
│   │
│   ├── Interfaces/
│   │   ├── IProductRepository.cs
│   │   ├── ICustomerRepository.cs
│   │   └── IOrderRepository.cs
│   │
│   └── Services/
│       └── DomainOrderService.cs   # Domain logic (e.g., calculating totals, order rules)
│
├── Application/                  # Use cases (business workflows)
│   ├── DTOs/
│   │   ├── OrderDto.cs
│   │   └── ProductDto.cs
│   │
│   ├── Interfaces/
│   │   └── IOrderService.cs
│   │
│   └── Services/
│       ├── ProductService.cs      # Uses repos + domain logic
│       ├── CustomerService.cs
│       └── OrderService.cs
│
├── Infrastructure/                # Implementation details (DB, APIs, File system, External services)
│   ├── Persistence/
│   │   ├── FileDatabase.cs
│   │   ├── ProductRepository.cs
│   │   ├── CustomerRepository.cs
│   │   └── OrderRepository.cs
│   │
│   └── Mappers/
│       └── DtoMappers.cs
│
├── UI/                            # Presentation layer (Console, Web, API, etc.)
│   └── Program.cs
│
└── Tests/                         # Unit + Integration tests
    ├── DomainTests/
    ├── ApplicationTests/
    └── InfrastructureTests/
```

### 🧩 Key Differences from Old Structure
1. Domain Layer
    + Pure business rules.
    + No dependencies on infrastructure (no JSON, DB, or file I/O code).
    + Entities (Product, Order), Value Objects (Money, Address), and Domain Services (order validation, pricing rules).
2. Application Layer
    + Orchestrates use cases.
    + Uses repositories (via interfaces) + domain services.
    + Returns DTOs to the UI.
3. Infrastructure Layer
    + Implements repository interfaces (e.g., JSON, SQL, API).
    + Handles persistence (your current FileDatabase).
4. UI Layer
    + Console, Web, or Desktop.
    + Talks only to Application layer.
    + No business logic here.

✅ This structure makes your mini e-commerce app much more modular, scalable, and testable. You can swap JSON persistence for SQL or an API later without touching the Domain or Application layers.