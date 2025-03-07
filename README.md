# 📄 DOCX to PDF Converter API  

## 🚀 Overview  
This is a .NET Core Web API that allows users to upload `.docx` files and convert them into `.pdf` format using **Spire.Doc**. The project follows a clean **layered architecture** with Controllers, Services, and Repositories.  

## 🏗 Architecture  
The project follows the **layered architecture**:  
- **Controllers** → Handle HTTP requests and responses  
- **Services** → Business logic layer (DOCX to PDF conversion, validations, etc.)  
- **Repositories** → Data access layer (if needed)  
- **Infrastructure** → External dependencies (Blob Storage, authentication, etc.)  

## 🔧 Technologies Used  
- **.NET Core** (ASP.NET Core Web API)  
- **Spire.Doc** (for DOCX to PDF conversion)  
- **Entity Framework Core** (for database operations)  
- **Azure Blob Storage** (for file storage, optional)  
- **JWT Authentication** (for securing endpoints)  
- **Swagger** (for API documentation)  

## 📌 Features  
✅ Upload `.docx` files via API  
✅ Convert `.docx` to `.pdf`  
✅ Store files in **Azure Blob Storage** (optional)  
✅ Download converted PDF files  
✅ JWT-based authentication for secure access  

## 📂 API Endpoints  

### **1️⃣ Upload a DOCX File**  
```http
POST /api/docx/upload
```
**Request (multipart/form-data):**  
| Key   | Value  |
|--------|----------|
| `file` | Upload a `.docx` file |

**Response:**  
```json
{
  "message": "File uploaded successfully",
  "pdfUrl": "https://yourstorage.com/documents/sample.pdf"
}
```

### **2️⃣ Convert DOCX to PDF (Manually)**  
```http
POST /api/docx/convert
```
**Request (JSON):**  
```json
{
  "fileUrl": "https://yourstorage.com/documents/sample.docx"
}
```
**Response:**  
```json
{
  "message": "Conversion successful",
  "pdfUrl": "https://yourstorage.com/documents/sample.pdf"
}
```

### **3️⃣ Download PDF File**  
```http
GET /api/docx/download/{fileName}
```
**Response:** Returns the converted PDF file.  

## 🛠 Setup & Installation  

### **1️⃣ Clone the Repository**  
```bash
git clone https://github.com/yourusername/your-repo.git
cd your-repo
```

### **2️⃣ Install Dependencies**  
Make sure you have the required dependencies installed:  
```bash
dotnet restore
```

### **3️⃣ Configure `appsettings.json`**  
Set your database connection and Azure Blob Storage credentials (if used).  

### **4️⃣ Run the API**  
```bash
dotnet run
```
The API will be available at: **`http://localhost:5000`**  


## 📜 License  
This project is open-source and licensed under the **MIT License**.  

---  
  
🚀 **Happy Coding!**

