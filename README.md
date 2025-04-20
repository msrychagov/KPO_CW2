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

## 🗂 Структура репозитория

