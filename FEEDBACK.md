# Feedback - INSPAND Full Stack Challenge

## 🧠 Entendimento das Camadas

### Domain

Responsável por conter as entidades e regras de negócio puras da aplicação, sem dependência externas.

### Infrastructure

Implementa os repositórios, acesso ao banco de dados e serviços externos (como envio de e-mail).

### WebApp

Camada que expõe a aplicação (API), recebe as requisições HTTP e direciona para os casos de uso corretos.

## 🔧 Ponto de melhoria

A separação de responsabilidades está bem clara, mas senti falta de um projeto separado para a **camada de Application**, que deixaria a arquitetura ainda mais alinhada com o conceito de Clean Architecture.

Nao usei a interface do Iservice, Em vez disso, criei casos de uso separados cada um com sua lógica específica, o que torna o código mais modular, testável e coeso.

Um ponto de melhoria que eu aplicaria no projeto seria a adoção de cache na listagem de livros, especialmente se o volume de dados for alto ou houver muita consulta repetida.

Implementaria um middleware de exception handling para retornar erros padronizados, com status HTTP apropriados e mensagens claras para o front.

Se o tempo permitisse, criaria testes para os casos de uso principais

Integraria o Swagger para facilitar o teste manual dos endpoints e a comunicação entre backend e frontend.
