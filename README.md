# Sprint 3 - Challenge: C# Software Development

---
## Integrantes

- Aline Fernandes Zeppelini - RM97966
- Camilly Breitbach Ishida - RM551474
- Julia Leite Galvão - RM550201
- Jessica Costacurta - RM99068

---
## Descrição do projeto

Este projeto é uma aplicação desenvolvida em C# que implementa um sistema de cadastro e gerenciamento de clientes e funcionários. O sistema utiliza banco de dados relacional para persistência das informações, além de manipular um arquivo JSON gerado pelo próprio código para armazenar logs e dados auxiliares.

O objetivo é fornecer uma solução completa para o gerenciamento de clientes e controle por parte de funcionários, com funcionalidades de autenticação, administração de perfis e simulação de investimentos.

O sistema permite que clientes realizem seu cadastro e efetuem login para acessar a plataforma. Uma vez autenticados, os clientes podem atualizar seus dados e alterar o perfil de investidor sempre que desejarem, recebendo ainda uma simulação de rendimento baseada no perfil escolhido, o que auxilia na tomada de decisão financeira. Já os funcionários, ao efetuarem login, têm acesso a funcionalidades administrativas que incluem a consulta da quantidade total de usuários cadastrados, bem como a distribuição desses usuários de acordo com seus perfis de investidor. Além disso, podem listar todos os clientes do sistema e, quando necessário, realizar a exclusão de registros. Dessa forma, a aplicação oferece um ambiente completo tanto para a interação do cliente com seus dados quanto para o gerenciamento e monitoramento por parte dos funcionários.

---
## Configurações e observações

1. Para conectar com o banco de dados Oracle, coloque seu usuário e senha na variável `connectionString`
2. O arquivo json lido pelo programa é criado na pasta `bin`

---
## Exemplos

### 1. Cadastro de Clientes

<img width="502" height="201" alt="image" src="https://github.com/user-attachments/assets/ce9268ca-097e-4fc5-b7df-676e9f69f109" />


### 2. Login e Menu de Clientes

<img width="554" height="253" alt="image" src="https://github.com/user-attachments/assets/99960cbf-0c98-4e99-b1d6-d45275249293" />
<img width="477" height="333" alt="image" src="https://github.com/user-attachments/assets/ad9aa5d6-2a42-4781-9614-bedc387b9af2" />
<img width="404" height="320" alt="image" src="https://github.com/user-attachments/assets/e22f5d68-a096-4522-8f30-b3cef7a13f71" />


### 3. Login e Menu de Funcionários

<img width="643" height="390" alt="image" src="https://github.com/user-attachments/assets/597caa9d-9c40-4c34-b48c-ed32b69dbdb6" />
<img width="694" height="390" alt="image" src="https://github.com/user-attachments/assets/47517ac0-aaa3-4f48-8b3a-2ba0ec39f844" />
<img width="371" height="370" alt="image" src="https://github.com/user-attachments/assets/4c5d0d2d-e79c-4632-b95b-7487167c81fb" />


---
## Arquitetura em diagramas

<img width="752" height="619" alt="image" src="https://github.com/user-attachments/assets/2e52837f-e553-4f7a-bc4d-3bc7115ff79f" />

