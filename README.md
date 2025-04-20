# ZooManagement

![.NET](https://img.shields.io/badge/.NET-9.0-blue) ![C%23](https://img.shields.io/badge/C%23-9.0-blue) ![xUnit](https://img.shields.io/badge/Tests-xUnit-green)

Автоматизированная система управления зоопарком:  
— учёт животных и вольеров  
— организация расписания кормлений  
— сбор статистики  

Реализовано с применением **Domain‑Driven Design** и **Clean Architecture** на стеке C# / .NET 9.0 / ASP.NET Core Web API.

---

## 📋 Описание

**Заказчик**: Московский зоопарк  
**Задачи**:
1. CRUD для животных и вольеров  
2. Перемещение животных между вольерами  
3. Планирование и учёт кормлений  
4. Просмотр статистики (кол‑во животных, свободные места)  

**Основные концепции**:
- Богатая доменная модель (Entity, Value Object, Domain Event)  
- Слои:  
  - **Domain** (модели, интерфейсы DomainEvents)  
  - **Application** (сервисы бизнес‑логики)  
  - **Infrastructure** (in‑memory репозитории)  
  - **Presentation** (REST API контроллеры + Swagger)  
- Принципы Clean Architecture: зависимости “внутрь”, изоляция бизнес‑логики  
- Domain‑Driven Design: инкапсуляция бизнес‑правил внутри сущностей

---

```markdown
# 🦁 ZooManagement

![.NET](https://img.shields.io/badge/.NET-9.0-blue) ![C%23](https://img.shields.io/badge/C%23-9.0-blue) ![xUnit](https://img.shields.io/badge/Tests-xUnit-green)

Автоматизированная система управления зоопарком:
- учёт животных и вольеров  
- организация расписания кормлений  
- сбор статистики  

Реализовано с применением **Domain‑Driven Design** и **Clean Architecture**  
Технологии: C# / .NET 9.0 / ASP.NET Core Web API / xUnit

---

# 🦁 ZooManagement

Автоматизированная система управления зоопарком на стеке  
C# / .NET 9.0 / ASP.NET Core Web API / xUnit  
(DDD + Clean Architecture)

---

## 📂 Структура репозитория

- **ZooManagement.sln**  
- **src/**
  - **ZooManagement.Domain/** *(Domain Layer)*
    - `DomainEvents.cs`  
    - **Entities/**
      - `Animal.cs`  
      - `Enclosure.cs`  
      - `FeedingSchedule.cs`  
    - **Events/**
      - `AnimalMovedEvent.cs`  
      - `FeedingTimeEvent.cs`  
    - **ValueObjects/**
      - `Gender.cs`  
      - `EnclosureType.cs`  
  - **ZooManagement.Application/** *(Application Layer)*
    - **Interfaces/**
      - `IAnimalRepository.cs`  
      - `IEnclosureRepository.cs`  
      - `IFeedingScheduleRepository.cs`  
    - **Services/**
      - `AnimalTransferService.cs`  
      - `FeedingOrganizationService.cs`  
      - `ZooStatisticsService.cs`  
  - **ZooManagement.Infrastructure/** *(Infrastructure Layer)*
    - **Repositories/**
      - `InMemoryAnimalRepository.cs`  
      - `InMemoryEnclosureRepository.cs`  
      - `InMemoryFeedingScheduleRepository.cs`  
  - **ZooManagement.WebApi/** *(Presentation Layer)*
    - `Program.cs`  
    - **Controllers/**
      - `AnimalsController.cs`  
      - `EnclosuresController.cs`  
      - `FeedingSchedulesController.cs`  
- **tests/**
  - **ZooManagement.Tests/** *(Unit Tests)*
    - **DomainTests/**
      - `AnimalTests.cs`  
    - **ApplicationTests/**
      - `AnimalTransferServiceTests.cs`  

---
```

---

## 🚀 Быстрый старт

### 1. Клонирование

```bash
git clone https://github.com/<ваш‑путь>/ZooManagement.git
cd ZooManagement
```

### 2. Сборка и тестирование

```bash
dotnet restore
dotnet build
dotnet test
```

### 3. Запуск Web API

```bash
dotnet run --project src/ZooManagement.WebApi
```

- HTTP:  `http://localhost:5000`  
- HTTPS: `https://localhost:5001`

Swagger UI:  
```
https://localhost:5001/swagger
```

---

## 🔌 REST API

### 🐾 Животные

| Метод         | Путь                    | Описание                     |
|---------------|-------------------------|------------------------------|
| GET           | /api/animals            | Список всех животных         |
| GET           | /api/animals/{id}       | Информация по животному      |
| POST          | /api/animals            | Создать новое животное       |
| DELETE        | /api/animals/{id}       | Удалить животное             |

Пример тела POST `/api/animals`:
```json
{
  "species":     "Lion",
  "name":        "Simba",
  "dateOfBirth": "2021-06-01T00:00:00",
  "gender":      0,                 // 0=Male,1=Female,2=Unknown
  "favoriteFood":"Meat"
}
```

---

### 🏟 Вольеры

| Метод         | Путь                       | Описание                 |
|---------------|----------------------------|--------------------------|
| GET           | /api/enclosures            | Список всех вольеров     |
| GET           | /api/enclosures/{id}       | Информация по вольеру    |
| POST          | /api/enclosures            | Создать новый вольер     |
| DELETE        | /api/enclosures/{id}       | Удалить вольер           |

Пример тела POST `/api/enclosures`:
```json
{
  "type":     1,      // 0=Predator,1=Herbivore,2=Aviary,3=Aquarium
  "size":     50.0,
  "capacity": 5
}
```

---

### 🍽 Расписание кормлений

| Метод         | Путь                                       | Описание                    |
|---------------|--------------------------------------------|-----------------------------|
| GET           | /api/feedingschedules                      | Список расписаний кормлений |
| POST          | /api/feedingschedules                      | Создать расписание кормления|
| POST          | /api/feedingschedules/feed/{scheduleId}    | Отметить кормление          |

Пример тела POST `/api/feedingschedules`:
```json
{
  "animalId": "GUID_животного",
  "time":     "2025-04-21T10:00:00",
  "foodType": "Grass"
}
```

---

## 🧪 Тестирование

- Все юнит‑тесты находятся в папке `tests/ZooManagement.Tests/`
- Фреймворк: **xUnit**
- Запуск:
  ```bash
  dotnet test
  ```

Покрытие основных сценариев > 65%.

---

## 📚 Ресурсы и литература

- **Domain‑Driven Design** — Eric Evans  
- **Implementing Domain‑Driven Design** — Vaughn Vernon  
- **Clean Architecture** — Robert C. Martin  
- **ASP.NET Core Web API** — Microsoft Docs  
- **Swashbuckle / Swagger** — https://github.com/domaindrivendev/Swashbuckle.AspNetCore  

---

## ✍️ Автор

**[Ваше Имя]** — студент, Выполнил ДЗ по курсу «Конструирование ПО»  
По вопросам и предложениям — создавайте Issues или PR в этом репозитории.  
```
