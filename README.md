# Patient REST API

## Task Description

### 1. Create a REST API application with CRUD operations for the `Patient` entity  
The entity represents newborns in a maternity hospital.

#### Example JSON representation:
```json
{
  "name": {
    "id": "d8ff176f-bd0a-4b8e-b329-871952e32e1f",
    "use": "official",
    "family": "Ivanov",
    "given": [
      "Ivan",
      "Ivanovich"
    ]
  },
  "gender": "male",
  "birthDate": "2024-01-13T18:25:43",
  "active": true
}
```

#### Required fields:
- `name.family`
- `birthDate`

#### Reference dictionaries:
- **Gender:** `male` | `female` | `other` | `unknown`
- **Active:** `true` | `false`

The application should be developed using **.NET Core (.NET 6)** with any database of choice.

---

### 2. Implement search functionality for `Patient` by the `birthDate` field  
The search should comply with the [HL7 FHIR date search specification](https://www.hl7.org/fhir/search.html#date).

search condition
"lt" => p.BirthDate < birthDate,
"le" => p.BirthDate <= birthDate,
"gt" => p.BirthDate > birthDate,
"ge" => p.BirthDate >= birthDate,
"ne" => p => p.BirthDate != birthDate,
"sa" => p => p.BirthDate > birthDate,
"eb" => p => p.BirthDate < birthDate,
"ap" => p => Math.Abs((p.BirthDate - birthDate).TotalDays) <= 5,
_ => p => p.BirthDate.Date == birthDate.Date

---

### 3. Add API documentation using **Swagger**.

---

### 4. Develop a console application  
The application should generate **100 Patient entities** and add them via the API.

---

### 5. Containerization with Docker  
- Create a **Dockerfile**  
- Configure the system to run (including the database) within **Docker containers**  

---

### 6. Create a Postman collection to demonstrate API methods:
- Add a patient  
- Edit a patient  
- Retrieve a patient by ID  
- Delete a patient  
- Various search queries using the `birthDate` parameter  

---

### 7. Publish the project  
The final implementation should be placed in a **public Git repository** (GitHub, GitLab, etc.).
