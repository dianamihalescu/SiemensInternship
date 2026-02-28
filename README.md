# Siemens Internship – Order Management System (C# / .NET)

Console application built in **C#** using **.NET** (`dotnet`) for managing customer orders and applying a discount rule.
## Problem 1 – Diagrams

- Class Diagram (UML): docs/Problem1_ClassDiagram.png
- ER Diagram (Database): docs/Problem1_ERD.png
## Problem 2 - Requirements covered

### 2.1 Create the C# classes
- **Customer**: `Name`, `Email`
- **OrderItem**: `ProductName`, `Price (decimal)`, `Quantity (int)`, `GetTotal()`
- **Order**: `Customer`, list of `OrderItem`, methods for totals & discount
- **OrderService**: printing + analytics (top spender, popular products)

### 2.2 Final price calculation (discount rule)
Discount policy:
- If the **subtotal exceeds 500€**, apply **10% discount** on the entire order.
Implemented via:
- `Order.GetSubtotal()`
- `Order.GetFinalTotal()` (applies discount when applicable)

### 2.3 Top spender customer
Implemented in `OrderService.GetTopSpenderCustomerName(List<Order> orders)`
- Groups orders by customer name
- Sums `GetFinalTotal()` per customer
- Returns the customer with the highest total

### 2.4 (Bonus) Popular products + total quantity sold
Implemented in `OrderService.GetPopularProductsWithTotalQuantity(List<Order> orders)`
- Flattens all order items
- Groups by product name
- Returns a dictionary: `ProductName -> TotalQuantity`

## How to run

### Prerequisites
- Install **.NET SDK** (for `dotnet` CLI)

### Run
```bash
dotnet run
