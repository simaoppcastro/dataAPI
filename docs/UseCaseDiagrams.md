# Diagramas de Casos de Uso
## Login e Registo
![Login e Registo](/images/usecase_login_v1.PNG)

## Lista de Casos de Uso - Login e Registo

Caso de Uso             | Descrição                                                      | 
-------------           | -------------------------------------------------------        | 
Registo Utilizador      | Pedido de registo de um novo utilizador da plataforma          | 
Validação (New User)    | Validação dos dados de registo (por parte do administrador)    |   
Não válido (New User)   | Administrador não valida o novo registo criado pelo utilizador | 
Admin valida (New User) | Confirmação da validação do novo registo                       | 
Adicionar user DB       | Após confirmação do admin, adicionar user à BD                 | 
Confirmação DB          | Confirmação da BD dos dados inseridos corretamente             | 
Não confirmado (DB)     | Dados não foram inseridos corretamente na BD                   |
Login (User)            | Login do utilizador, com inserção dos respectivos dados        |
Dados autenticados      | Dados corretos e autenticados corretamente                     | 
Acesso concedido        | Sistema e BD valida credenciais (envia mensagem OK)            | 
Acesso não concedido    | Sistema ou BD não valida as credenciais (envia mensagem NOK)   |

### Registo Utilizador

Nome do Caso de Uso | Login e Registo (Registo Utilizador)      | 
--------------------|------------------------------------------ |
Objectivo           | Registo (email password) novo utilizador  |
Requisitos          | Dados de registo e aprovação do admin     |
Actores             | New User, Administrador, BD e Sistema     | 
Prioridade          | Alta para acesso à plataforma             |
Pré-condições       | Nenhuma                                   |
Frequência de Uso   | Sempre para novos User                    |
Pós-condições       | Credenciais validades durante acesso      |
Campos              | Dados pessoais, email e password          |
Fluxo principal     | a) Validação; b) Adicionar à BD;          | 
...                 | c) Confirmação BD;                        |


### Adicionar user DB

Nome do Caso de Uso | Login e Registo (Adicionar user DB)          | 
--------------------|--------------------------------------------- |
Objectivo           | Adicionar dados do novo user à BD            |
Requisitos          | Dados corretos (user não pode existir na BD) |                  
Actores             | New User; Sistema e BD                       |
Prioridade          | Alta                                         |
Pré-condições       | Administrador aprovar novo utilizador        |
Frequência de Uso   | Sempre que um novo utilizador é registado    |
Pós-condições       | User não existir na BD; Dados correctos;     |
Campos              | ID; Username; Email; Password;               |
Fluxo principal     | a) admin valida; b) INSERT NewUser;          |
...                 | c) Confirmação da inserção do novo user;     |

### Acesso concedido

Nome do Caso de Uso | Login e Registo (Acesso concedido)                                       | 
--------------------|------------------------------------------------------------------------- |
Objectivo           | Confirmar acesso do utilizador à plataforma, após correta autentificação |
Requisitos          | Login com confirmação da autentificação dos dados por parte do sistema   |
Actores             | Utilizador; BD e sistema; Aplicação                                      |
Prioridade          | Alta                                                                     |
Pré-condições       | Autentificação dos dados de login                                        |
Frequência de Uso   | Sempre que utilizador acede à aplicação                                  |
Pós-condições       | Redirecionamento para a aplicação (página pessoal)                       |                                   
Campos              | Resposta OK ou NOK por parte da BD e Sistema                             |
Fluxo principal     | a) Login; b) Dados autenticados; c) Confirmação do sistema;              |
...                 | d) Redirecionamento para a aplicação;                                    | 
