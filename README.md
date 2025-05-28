# 💸 CorePay API - Money Transfer

A RESTful API built with .NET to handle balance transfers between users. This project simulates a simple and straightforward payment system with user and balance management.

---

## 🚀 Technologies Used

- ASP.NET Core
- Entity Framework Core
- SQL Server (or SQLite, as configured)
- C#

---

## ⚙️ How to Run the Project

```bash
# Clone the repository
git clone https://github.com/your-username/CorePayAPI.git

# Navigate into the folder
cd CorePayAPI

# Restore dependencies
dotnet restore

# Run the project
dotnet run
```

The API will be available at: `https://localhost:5001` or `http://localhost:5000`

---

## 📨 Transfer Endpoint

### `POST /api/Transaction/Transfers`

Performs a money transfer between two users.

#### ✅ Sample Request:

```json
{
  "senderId": 1,
  "receiverId": 2,
  "amount": 100.00
}
```

#### 🔁 Sample Response (success):

```json
{
  "message": "Transfer completed successfully.",
  "senderId": 1,
  "senderName": "Alice",
  "senderBalance": 900.0,
  "receiverId": 2,
  "receiverName": "Bob",
  "receiverBalance": 1100.0
}
```

#### ⚠️ Sample Response (error):

```json
{
  "errorMessage": "Insufficient balance."
}
```

---

## ❌ Possible Errors

| Status Code | Description               |
|-------------|---------------------------|
| 400         | Insufficient balance       |
| 404         | User not found             |
| 500         | Internal server error      |

---

## 📌 Notes

- Users must be pre-registered in the database.
- This version does not include authentication.
- Follows a layered architecture: Controller → Service → Repository → DbContext.

---

## 🧑‍💻 Author

Developed by [Namanosbad](https://github.com/Namanosbad)
