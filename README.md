# 🎮 ArcadeScore

Sistema desenvolvido como teste técnico para registrar e consultar pontuações de jogadores em jogos de arcade.

---

## 📚 Tecnologias Utilizadas

### Frontend (Angular)
- Angular v17+ (Standalone APIs)
- Angular SSR (Server-Side Rendering)
- Angular Router
- Reactive Forms
- HttpClient com `withFetch()` habilitado
- Estilização via SCSS
- Responsivo (CSS puro)

### Backend (ASP.NET Core)
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server (LocalDB)
- API RESTful
- CORS habilitado
- Certificado HTTPS local (autoassinado)

---

## 🧩 Funcionalidades

### ✅ Registro de Pontuação
- Formulário com validação de campos obrigatórios
- Envio assíncrono via serviço (`ScoreService`)
- Armazenamento no banco local via EF

### ✅ Ranking (Top 10)
- Tabela responsiva com:
  - Posição
  - Jogador
  - Pontuação
  - Data
  - Acesso às estatísticas individuais

### ✅ Estatísticas do Jogador
- Total de partidas
- Média de pontuação
- Maior e menor pontuação
- Primeira e última partida
- Quantidade de vezes que bateu o próprio recorde
- **Tempo que joga** (formatado em meses ou anos)

---

## 🏗️ Estrutura do Projeto

```
/src
├── app
│   ├── components
│   │   ├── register-score/
│   │   ├── ranking/
│   │   └── player-stats/
│   ├── services/
│   │   └── score.service.ts
│   ├── app.component.ts / .html / .scss
│   ├── app.routes.ts
│   └── app.config.ts
```

---

## ⚙️ Como Rodar o Projeto

### 📦 Requisitos
- Node.js 18+
- .NET SDK 7.0+
- SQL Server LocalDB

---

### 🔧 Passos para Executar

#### 1. Backend (API)
```bash
cd Desafio.ArcadeScore
dotnet restore
dotnet ef database update
dotnet run
```

#### 2. Frontend (Angular)
```bash
cd arcade-score
npm install

# Para SSR com proxy:
npm run start:proxy
```

---

### 🛡️ CORS e HTTPS (caso SSR dê erro)
Para evitar erros com certificados autoassinados, rode no backend:

```bash
dotnet dev-certs https --trust
```

Ou, para ignorar no SSR (temporário e apenas em dev):

```ts
// main.server.ts
process.env.NODE_TLS_REJECT_UNAUTHORIZED = '0';
```

**observação: item não usado durante desenvolvimento(parte de evitar warning, cors foi sim habilitado para desenvolvimento e acesso da api)**.
---

## 📄 Observações Finais

- O projeto foi desenvolvido com foco em **boas práticas**, separação de responsabilidades (serviços, componentes) e **responsividade**.
- O layout foi feito com base nos requisitos do teste, simulando uma interface moderna e funcional.

---

## 👨‍💻 Autor

Rafael de Castro Silva
