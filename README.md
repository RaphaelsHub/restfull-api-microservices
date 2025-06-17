# 🔗 Restful API Services (Microservices Architecture)

This repository contains independent microservices, each implemented as a standalone ASP.NET Core Web API:

- `AlphaApi`
- `BetaApi`

## 🧩 Architecture Overview

Each API represents a self-contained **microservice**, designed to:

- Be deployed **independently** in Docker containers  
- Communicate with other services via **HTTP** within a shared Docker **network**
- Follow the **RESTful API** pattern

This setup demonstrates a modular architecture where services are loosely coupled but can collaborate through internal APIs — a core idea behind **microservice-based systems**.

> ✅ Ideal for experimenting with service decoupling, scalability, and Docker networking.
