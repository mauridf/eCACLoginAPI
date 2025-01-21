
# eCACLoginAPI

## Descrição
A **eCACLoginAPI** é uma API web desenvolvida em C# com .NET para realizar login no sistema e-CAC utilizando as seguintes opções:

1. **Login via Gov.br** - utilizando usuário e senha.
2. **Login via Certificado Digital do tipo A1**.

O objetivo principal é fornecer um serviço simples que autentique com sucesso no sistema e-CAC e retorne o status da operação.

---

## Funcionalidades
- Login via Gov.br:
  - Envio de credenciais (usuário e senha) via `POST` para o endpoint de autenticação do Gov.br.
- Login via Certificado Digital:
  - Uso de certificados digitais do tipo A1 para autenticação segura com o e-CAC.

---

## Requisitos
### Ferramentas e Bibliotecas
- **.NET SDK** (versão 8.0 ou superior)
- **Visual Studio 2022** (ou outra IDE de sua preferência)
- **RestSharp** (para requisições HTTP)

### Dependências
Instale as dependências utilizando o comando:
```bash
dotnet add package RestSharp
```

---

## Configuração do Ambiente

1. Clone o repositório:
   ```bash
   git clone https://github.com/seuusuario/eCACLoginAPI.git
   cd eCACLoginAPI
   ```

2. Restaure os pacotes NuGet:
   ```bash
   dotnet restore
   ```

3. Compile o projeto para verificar erros:
   ```bash
   dotnet build
   ```

---

## Uso

### Execução Local
Para rodar a API localmente, execute o comando:
```bash
dotnet run --project eCACLoginAPI
```

A API estará disponível no endereço:
```
http://localhost:5000
```

### Exemplos de Endpoints

#### Login com Gov.br
**POST** `/api/login/govbr`

**Body:**
```json
{
  "username": "seuUsuario",
  "password": "suaSenha"
}
```

**Resposta de Sucesso:**
```json
{
  "success": true,
  "message": "Login realizado com sucesso."
}
```

**Resposta de Falha:**
```json
{
  "success": false,
  "message": "Credenciais inválidas."
}
```

#### Login com Certificado Digital
**POST** `/api/login/certificate`

**Body:**
```json
{
  "certificatePath": "caminho/para/certificado.pfx",
  "certificatePassword": "suaSenha"
}
```

**Resposta de Sucesso:**
```json
{
  "success": true,
  "message": "Login realizado com sucesso."
}
```

**Resposta de Falha:**
```json
{
  "success": false,
  "message": "Erro ao realizar login."
}
```

---

## Estrutura do Projeto

- `eCACLoginAPI/Services/`
  - **GovBrLoginService.cs**: Serviço para login via Gov.br.
  - **CertificateLoginService.cs**: Serviço para login com certificado digital.
- `eCACLoginAPI/Controllers/`
  - **LoginController.cs**: Controlador principal para gerenciar os endpoints de login.
