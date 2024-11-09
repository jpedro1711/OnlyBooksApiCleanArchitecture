# Introduction and Goals

O OnlyBooks é um aplicativo de:

- Gerenciamento de Livros
- Controle de Disponibilidade de Livros
- Interface intuitiva ao usuário
- Voltado para estudantes e corpo doscente

## Requirements Overview

Um sistema que permita o empréstimo de livros de maneira ágil e intuitiva. Será resolvido o problema de bibliotecas, que não usam tecnologia na gestão e administração de seus livros, o que resulta em perda de tempo com processos manuais e dificuldades em gerenciar livros.O sistema visa modernizar a gestão de bibliotecas, substituindo processos manuais por uma solução tecnológica ágil e intuitiva para o empréstimo e administração de livros. O sistema permitirá o cadastro e autenticação de usuários com nome completo, e-mail e senha, facilitando o login. Os usuários poderão visualizar livros em formato de catálogo, reservar livros disponíveis, filtrar por gênero, e acessar detalhes e avaliações dos livros. A busca e ordenação de livros serão possíveis por avaliação e status, com restrições para reservas de livros indisponíveis.
Administradores e bibliotecários poderão gerenciar e cadastrar livros, emitir relatórios sobre livros emprestados, e acompanhar empréstimos e reservas pendentes. O sistema garantirá respostas a consultas em até 10 segundos e será compatível com os principais navegadores web, com uma interface intuitiva e personalizável. Projetado de forma modular, o sistema permitirá fácil manutenção e adaptação a novas tecnologias e mudanças. Além disso, garantirá processos de login e autenticação rápidos e confiáveis, mantendo a precisão e consistência dos dados. O controle de versão será utilizado para o gerenciamento de código, e a documentação clara será fornecida para APIs, facilitando a integração com desenvolvedores externos.

Diagrama de caso de uso e documento listando os requisitos funcionais e não funcionais por número se encontra no [GitHub](https://github.com/jpedro1711/pjbl-arq-software).

## Quality Goals 

| **Meta de Qualidade**  | **Motivação/Justificação**                                                                    |
| ---------------------- | --------------------------------------------------------------------------------------------- |
| Performance/Eficiência | Escalabilidade do servidor em caso de sobrecarga de usuários                                  |
| Usabilidade            | Sistema deverá ser de fácil navegação para acomodar seus usuarios de perfis e faixas etárias variadas         |
| Compatibilidade        | Sistema deverá possuir facil integração com suas APIs                                                 |
| Adequação Funcional    | Sistema deverá se adequar aos requisitos pré-definidos no escopo                              |
| Mantenabilidade        | Sistema deverá ser de fácil manutenção e de fácil implantação de melhorias fisicas e digitais |

## Stakeholders 

| **Stakeholder** | **Expectativa**                                               | **Impacto** |
| --------------- | ------------------------------------------------------------- | ----------- |
| Bibliotecário   | Sistema intuitivo que facilite seu trabalho                   | Alto        |
| Estudante       | Sistema rápído que agilize processo de empréstimo de livros   | Médio       |
| Pesquisador     | Sistema que facilite encontrar artigos e materiais            | Médio       |
| Docente         | Sistema que permita encontrar materiais didáticos rapidamente | Médio       |
| Leitor Comum    | Sistema rapído que agilize processo de emprestimo de livros   | Baixo       |

_Alto = Impactado diretamente pelo sistema_ <br>
_Médio = Impactado indiretamente pelo sistema_ <br>
_Baixo = Pouco impactado pelo sistema_

# Architecture Constraints 

## Technical Constraints

- Stack de Linguagens: O sistema deverá ser desenvolvido utilizando a stack de linguagen aprovada previamente, que incluem C# para back-end e TypeScript para front-end, biblioteca React.
- Stack de Tecnologias: O sistema deverá ser desenvolvido utilizado stack de tecnologias aprovada, que incluem Microsoft Sql Server, MongoDB, e Redis para memória cache.
- Integração: O sistema deverá utlizar RESTful APIs para integração com sistemas externo. Todos as APIs deveram estar documentadas e estarem dentro do padrão de documentação de APIs da Microsoft Azure.

## Organizational Constraints

- Time: Guilherme Gruner Birckholz, Luiz Gustavo Chimenes Pinto, João Pedro Igeski Morais, João Vitor Wielewski de Assis e Otavio Dallo Costa.
- Agenda: Início em setembro de 2024, possuindo reuniões semanais aos sábados, além de encontros durante as aulas de Arquitetura de Soluções Cloud às segundas e sextas.
- Configuração e Sistema de Controle de Versão: Reposiório Git privado com histórico de commits e uma branch master pública públicada no GitHub com um link no documento Arch42 do projeto

# System Scope and Context

## Business Context 

### C4 Model nível 1![](https://mermaid.ink/img/pako:eNqNUslOwzAQ_ZXRnIqUViROl-QICK6IigvKxW2mxVJiFy8VperHcOQ7-mM4TboEtai-eDbPe2_Ga5yqnDDF-_heSUufNpPgjxW2IBivjKUSmgw8CD7XvIQu3IlJIZSlKc9k_eCZtFGy44zjWqgAMnw1bvvtbcg5TI71eDkHH45gTprkVHDwnQxoMqSX3sgJCrHUymR400KcOV-t5B71sXYvIh-Y1xUtRGUajOAE1wddw9YAAZULvf0xVpQNlZpMPamOEdXFj-OpIMd1sJLwl43XUApLOxotoKXw8gvx5ad_YAUHqj7amk4PWo2OMLXI_auzAi9KeqHiuM6zwp6uXVXVqrWn_9tdwxEDLL1mLnL_edcVTIb2nUrKMPVmTjPuCpthJje-lDurxis5xdRqRwFq5ebvmM54YbznFjm31PzufcmCyzelTl1M1_iJaTdigx4LRwljbHgbD4aDAFdVOB71kjAMfXoU9qOIsU2AX7sWrBclYT-JWD_px9EoHkSbX6loOKQ?type=png)
Disponível em: [GitHub](https://github.com/jpedro1711/pjbl-arq-software/blob/main/c4level1.png)

## Technical Context 

### C4 Model nível 2![](https://mermaid.ink/img/pako:eNqVVttuGjEQ_RXLT6lEEppCCLxBKWmkXmhJValCqsx6oFZ37Y29JoWIj-lT1b73C_ixjte77AVo0xUgezw-M3PmsjzQQHGgPfq89VzJhAkJeioJPolIQiA7IRkKttAsIqdkIkwCESMcyEDMQqESCNhU-mtj0EbJE2ss00I1yJR-MHb7HdeEMzIr9OnxM3JngSxAgwwEI4hkiAYDeokLNBqKpVZmSp9ULM4taiuZWx357VHLO8-9RsWiMpmNRskuCm3mrSFAIIr19qdJRJS54p2ZrBw3nwfKSs706sR4rgqenO3DBNIn5MGDuGdHfIE11yh7IXkuSMN0MpC8druCcHIPs34cO_WPMCO4JJNx39OQCUIRsATp8sL-2upy6lHBH4y1WgrjWCaJ4sgKfnLeQ8EZB1PLZMw0q_A2L-XFnM8qWShy6p5NzukROlgsykwMWPD1X0T0xzcLlsA9Ww1GozTS8Q259pJzFGXhF0IveA9caEijJGkt3llkYftj-xvjTSNkxF1SlnjqXJCOznJl7HvjAqjUhcPg6kh__T0z7irWaow2t9-XEJIYQrWr6AhkoorWKcq6UcnNYvsLQdWhJsufI7EMZyczJgM1ZNzB545O3r3Kus0dOljuFJycTNABnDXeex2xNSC7_pgfaMBHeVr1rqgU58woy0m5ZryX-Ylnc698akkrY-1jlNNUlV3n06U8OTAUAyRQkZXYgW5BXiu5UMMB6Sch2-e_znrktZ2B2sUDtGcaBznXELK0wt2GOc_KbtYGaM2pTaVpK737HsLiXVDMoQ-JCMU6Gw95lepi2gLBOWOZ09G7BLuLL29vx5Nz97vzwpmoDP9Hm2nUc_EISzn43igZsTUq1CdDgZVCTSpYNYy9eVCeO8WY-S_IerUegjxQrEfQax5WW_7V9pd7L5pAwzKruKzShm_P3ry4rSJVHSuV8VGYvL6HWqSDA9Fog0aAdSw4_oNJ23ZKky8QwZT2cMlhzmyYTOlUblCV2URNVjKgvURbaFCt7OIL7c1ZaHBnY47EZf9ydtKYyU9KRfkV3NLeA_1Ge6cXnc5Z8_Ky2XraarWbF-0GXaH0stU9u-o-a19cXTXbVxedTYOu0_vPzprtZufyabON326329n8AehoK6U?type=png)
Disponível em: (https://evidenciaspjbl.blob.core.windows.net/evidencias/OnlyBooksContainer.png)

# Solution Strategy

## Objetivo
O sistema de gerenciamento de bibliotecas visa automatizar e otimizar o controle de empréstimos, devoluções, cadastro de acervo e gerenciamento de usuários, atendendo bibliotecas de pequeno a médio porte. A solução deve ser escalável, fácil de manter, segura e com interfaces amigáveis tanto para administradores quanto para usuários finais.

## 1. Arquitetura de Microserviços

Optamos por uma arquitetura baseada em microserviços para isolar as responsabilidades de cada parte do sistema, como autenticação de usuários, gerenciamento de acervo, transações de empréstimo, e relatórios. Isso facilita a escalabilidade, manutenção e deploy de forma independente dos serviços.

- **Frontend (React)**: 
  A aplicação frontend será desenvolvida utilizando React, priorizando uma experiência de usuário responsiva e moderna. O React permitirá o desenvolvimento de uma interface dinâmica e interativa, facilitando a manutenção e a expansão futura.

- **Backend (.NET Core)**:
  O backend será desenvolvido utilizando .NET Core para garantir alta performance, segurança e fácil integração com diferentes bancos de dados e serviços. O .NET Core será utilizado para implementar a API RESTful que servirá os dados para o frontend e outros serviços.

## 2. Estratégia de Banco de Dados

### **MongoDB (NoSQL)**
MongoDB será utilizado para armazenar informações relacionadas ao conteúdo dinâmico e não estruturado do sistema, como:

- Dados de empréstimos

### **MS SQL Server (SQL)**
O SQL Server será utilizado para o armazenamento de dados mais estruturados e transacionais, como:

- Dados de acervo de livros (detalhes, categorias, descrições, palavras-chave)
- Registros de histórico de atividades dos usuários (pesquisas, interações, logs)
- Informações que podem variar em estrutura ao longo do tempo, como resenhas e avaliações de livros.
- Informações de usuários (dados pessoais, perfis, permissões)
- Devoluções de livros
- Relatórios gerenciais e dados relacionados a transações financeiras (taxas de atraso, multas, etc.)
  
Utilizar ambos os bancos de dados permite uma combinação ideal de flexibilidade (com MongoDB) e robustez em transações (com SQL Server).

## 3. Estratégia de Integração

A integração entre o frontend (React) e o backend (.NET Core) será realizada por meio de APIs RESTful. Essas APIs permitirão comunicação assíncrona entre as camadas do sistema, garantindo independência entre o cliente e o servidor.

## 4. Escalabilidade

- **Escalabilidade Horizontal**: 
  A arquitetura em microserviços permitirá escalar individualmente cada componente do sistema com base na demanda. Por exemplo, o serviço de empréstimos pode ser escalado separadamente do serviço de relatórios.

## 5. Segurança

  
- **Criptografia de Dados**: 
  Todos os dados sensíveis, como informações de usuários e transações, serão criptografados tanto em trânsito quanto em repouso. MongoDB e SQL Server fornecem suporte nativo para criptografia de dados.

- **Auditoria e Log**: 
  Implementaremos mecanismos de auditoria e monitoramento para rastrear e registrar todas as interações dos usuários e transações relevantes. Logs detalhados serão mantidos para fins de segurança e análise.

## 6. Testes e Qualidade

Serão implementadas estratégias de testes automatizados para garantir a qualidade do sistema:

- **Testes Unitários**: Cobrirão a lógica interna dos serviços, garantindo que os componentes individuais funcionem corretamente.
- **Testes de Integração**: Validarão a comunicação entre os serviços e a base de dados.
- **Testes de Interface (UI)**: Realizados no frontend para garantir uma boa experiência de usuário.
- **Testes de Carga**: Serão realizados testes de estresse para verificar como o sistema se comporta em condições de alta carga.
- **Teste de Arquitetura**: Serão usados para garantir que a arquitetura do sistema está conforme os princípios de design estabelecidos, como modularidade, escalabilidade, separação de responsabilidades e uso eficiente de recursos.

## 7. Monitoramento 



- **Logs e Alertas**: Logs centralizados (com **Applictation Insights**) e alertas configuráveis permitirão que a equipe de suporte detecte e resolva problemas rapidamente.


# Building Block View

## Visão Geral

O sistema de gerenciamento de bibliotecas é composto por três camadas principais: o **Frontend** (React), o **Backend API** (.NET Core), e os **Bancos de Dados** (MongoDB e SQL Server). Abaixo, detalhamos os principais blocos de construção de cada camada.
![C4 Model Container]([https://evidenciaspjbl.blob.core.windows.net/evidencias/OnlyBooksContainer.png])
### 1. Frontend (React)

O frontend é responsável por fornecer a interface de usuário para bibliotecários e usuários. Ele se comunica com a API via requisições HTTP (REST) para enviar e receber dados. A interface é organizada em componentes React reutilizáveis.

#### Principais Componentes
- **Dashboard do Administrador**: Permite o gerenciamento de acervos, empréstimos, devoluções e usuários.
- **Área do Usuário**: Permite ao usuário visualizar o acervo, verificar o status de empréstimos e fazer reservas.


### 2. Backend API (.NET Core)

A API centraliza toda a lógica de negócio do sistema, servindo como a interface entre o frontend e os bancos de dados. Ela expõe endpoints RESTful para as funcionalidades do sistema, como gerenciamento de usuários, acervo e transações de empréstimo e devolução.

#### Principais Módulos

- **Gestão de Usuários**:
  - CRUD (Create, Read, Update, Delete) de perfis de usuários.
  - Controle de permissões de acordo com o tipo de usuário.

- **Gestão de Acervo**:
  - Manipulação do acervo de livros (inclusão, edição, exclusão).
  - Pesquisa e listagem de livros disponíveis no sistema.

- **Gestão de Transações**:
  - Controle de empréstimos e devoluções.
  - Cálculo de multas e prazos de devolução.

- **Relatórios**:
  - Geração de relatórios gerenciais, como o total de empréstimos, usuários ativos, e livros populares.
 

### 3. Banco de Dados

O sistema utiliza dois bancos de dados para armazenar as informações:

#### **MongoDB (NoSQL)**
Usado para armazenar dados não estruturados e dinâmicos.

- **Coleção Acervo**:
  - Contém informações sobre empréstimos
  

#### **MS SQL Server (SQL)**
Usado para armazenar dados transacionais e estruturados.

- **Tabela Usuários**:
  - Armazena dados de perfis de usuários, como nome, e-mail, senha, e permissões.

- **Tabela Livro**
  - Armazena dados de livros, como nome, genero e autor.

### 4. Integração Entre Componentes

- **API RESTful**: A comunicação entre o frontend (React) e o backend (.NET Core) é realizada via requisições HTTP usando APIs RESTful. O backend processa as requisições, acessa os bancos de dados e retorna as respostas necessárias ao frontend.
- ### C4 Model nível 3


# Runtime View

## Visão Geral

O **Runtime View** descreve o comportamento dinâmico do sistema em cenários específicos. Abaixo, destacamos os principais fluxos de operação no sistema de gerenciamento de bibliotecas, como login, consulta de acervo e empréstimo/devolução de livros. Cada cenário mostra como os componentes do sistema interagem entre si durante a execução.

### 1. Cenário: Autenticação de Usuário (Login)

Neste cenário, o usuário realiza o login no sistema para acessar suas funcionalidades, como consultar o acervo ou registrar empréstimos.

#### Fluxo
1. O usuário insere suas credenciais (e-mail e senha) na interface de login do **Frontend (React)**.
2. O **Frontend** envia uma requisição **POST** para o endpoint `/login` da **API (Backend .NET Core)**.
3. O **Backend** valida as credenciais verificando o **MS SQL Server**, onde os dados de usuário estão armazenados.
4. Se as credenciais forem válidas, a API cria uma **sessão** no servidor e retorna ao **Frontend** um **ID de sessão**.
5. O **Frontend** armazena o **ID de sessão** e o usa para autenticar as requisições subsequentes.

---

### 2. Cenário: Consulta de Acervo de Livros

O usuário consulta o acervo de livros disponíveis na biblioteca.

#### Fluxo
1. O usuário acessa a página de consulta de livros no **Frontend (React)**, que envia uma requisição **GET** para o endpoint `/livros` da **API**.
2. O **Frontend** inclui o **ID de sessão** na requisição para autenticação.
3. A **API** valida o **ID de sessão** e consulta o banco de dados **MongoDB**, onde os dados do acervo de livros estão armazenados.
4. A **API** retorna ao **Frontend** uma lista dos livros disponíveis.
5. O **Frontend** exibe a lista de livros para o usuário.


---

### 3. Cenário: Registro de Empréstimo de Livro

Neste cenário, um bibliotecário ou usuário registrado faz o registro de um empréstimo de livro.

#### Fluxo
1. O bibliotecário/usuário seleciona um livro para empréstimo no **Frontend (React)** e confirma a operação.
2. O **Frontend** envia uma requisição **POST** para o endpoint `/emprestimos` da **API** com os detalhes do usuário e do livro.
3. A **API** valida o **ID de sessão** e verifica a disponibilidade do livro no banco de dados **MongoDB**.
4. Se o livro estiver disponível, a **API** registra o empréstimo no banco de dados **MS SQL Server**.
5. A **API** retorna uma confirmação de sucesso ao **Frontend**, que atualiza a interface do usuário.

# Deployment View

## Visão Geral

O **Deployment View** descreve a infraestrutura física e lógica necessária para o funcionamento do sistema de gerenciamento de bibliotecas. Ele mostra como os componentes do sistema (frontend, backend, e bancos de dados) estão distribuídos entre os diferentes nós de infraestrutura.

### 1. Estrutura de Deployment

O sistema está distribuído em três ambientes principais:

- **Ambiente de Produção**: Onde o sistema está disponível para os usuários finais (bibliotecários, administradores, e leitores).
- **Ambiente de Desenvolvimento**: Usado pela equipe de desenvolvimento para implementar e testar novas funcionalidades.

A arquitetura segue uma abordagem em **nuvem** (cloud), com todos os componentes sendo implantados em serviços gerenciados ou auto-hospedados em uma infraestrutura baseada em nuvem.

### 2. Componentes de Deployment

#### 2.1. Frontend (React)
- **Serviço**: Hospedado em um **CDN (Content Delivery Network)**, como **AWS CloudFront** ou **Azure CDN** para servir os arquivos estáticos do React (HTML, CSS, JavaScript) aos navegadores dos usuários.
- **Build e Deployment**: O código React é empacotado e versionado para deploy em um servidor de arquivos estáticos.
- **Nó de Hospedagem**: Um bucket S3 (AWS) ou Blob Storage (Azure) pode ser usado para armazenar o aplicativo React com cache distribuído via CDN.
  
#### 2.2. Backend API (.NET Core)
- **Serviço**: Hospedado em um serviço de plataforma como serviço (PaaS), como **Azure App Service**. Também pode ser executado em containers com **Docker**.
- **Endpoint**: A API RESTful fica exposta para o frontend e outros clientes por meio de um endpoint HTTP (HTTPS) protegido, como o **API Gateway** (AWS) ou **Azure API Management**.
- **Balanceamento de Carga**: Um load balancer, como **Azure Load Balancer**, distribui as requisições entre instâncias da API.

#### 2.3. Banco de Dados
- **MongoDB**: Hospedado em um serviço gerenciado, como **MongoDB Atlas**, ou em uma instância de banco de dados auto-gerenciada, como no **Azure Cosmos DB** com API para MongoDB.
  - Armazena dados do acervo e logs de histórico de ações.
  
- **MS SQL Server**: Hospedado em um serviço gerenciado, como **Azure SQL Database** ou **


# Cross-Cutting Concepts

## Visão Geral

Os **Cross-Cutting Concepts** são aspectos transversais que impactam várias partes do sistema. Eles são essenciais para garantir que o sistema funcione de maneira eficiente, segura e confiável. Para o sistema de gerenciamento de bibliotecas, os principais conceitos transversais incluem:

1. **Segurança**
2. **Desempenho**
3. **Logging**
4. **Gerenciamento de Erros**

### 1. Segurança

#### Aspectos:
- **Autenticação**: 
  - **Frontend**: Os usuários se autenticam através de um formulário de login. As credenciais são enviadas ao **Backend API** para validação.
  - **Backend**: A autenticação é gerida no backend com controle de sessão e validação das credenciais armazenadas no **MS SQL Server**.
  
- **Autorização**:
  - Controle de acesso é baseado em permissões e papéis dos usuários. O **Backend API** verifica as permissões para determinar se um usuário pode acessar ou modificar determinados recursos.

- **Proteção de Dados**:
  - **HTTPS**: Todo o tráfego entre o **Frontend**, o **Backend** e os **Bancos de Dados** é criptografado usando HTTP para proteger os dados em trânsito.
  - **Criptografia de Dados**: Dados sensíveis são criptografados em repouso. Os dados dos usuários e informações confidenciais são armazenados com criptografia no **MS SQL Server**.

- **Segurança de API**:
  - **Rate Limiting**: Limitação de taxa de requisições para prevenir abusos e ataques DDoS.
  - **Firewall e Segurança de Rede**: Proteção de serviços com firewalls e regras de segurança para restringir o acesso.

### 2. Desempenho

#### Aspectos:
- **Escalabilidade**:
  - **Frontend**: Utiliza **CDN** para distribuir conteúdo estático e garantir tempos de resposta rápidos globalmente.
  - **Backend**: O **Backend API** é escalável horizontalmente, com múltiplas instâncias sendo geridas por um balanceador de carga para distribuir a carga.

- **Cache**:
  - **Frontend**: Utiliza cache de navegador e CDN para melhorar o tempo de carregamento das páginas.
  - **Backend**: **Redis** pode ser utilizado para cache de dados frequentemente acessados, reduzindo a carga nos bancos de dados e melhorando o desempenho das consultas.

- **Otimização de Consultas**:
  - **MongoDB** e **MS SQL Server** são otimizados com índices apropriados para melhorar o desempenho das consultas e operações de banco de dados.

### 3. Logging e Monitoramento

#### Aspectos:
- **Logging**:
  - **Backend**: O **Backend API** registra eventos e erros em logs para rastreamento e análise. Logs incluem informações sobre requisições, respostas, e exceções.
  - **Frontend**: Logs de erros e eventos do usuário são capturados e enviados para o backend ou um serviço de monitoramento.

- **Monitoramento**:
  - **Aplicação**: Uso de ferramentas como **Azure Monitor**, **AWS CloudWatch**, ou **ELK Stack** para monitorar a saúde do sistema, performance da API, e métricas de uso.
  - **Infraestrutura**: Monitoramento da infraestrutura (como servidores e bancos de dados) para garantir que recursos suficientes estejam disponíveis e o sistema esteja funcionando corretamente.

### 4. Gerenciamento de Erros

#### Aspectos:
- **Tratamento de Erros**:
  - **Frontend**: Erros são capturados e exibidos ao usuário de forma amigável. Mensagens de erro são genéricas para evitar exposição de detalhes internos.
  - **Backend**: Erros são tratados com mensagens apropriadas e registrados nos logs. O sistema deve retornar códigos de erro HTTP apropriados (por exemplo, 404 para não encontrado, 500 para erro interno).

---

# Architectural Decisions

## Visão Geral

As **Architectural Decisions** são escolhas fundamentais que definem a estrutura e o funcionamento do sistema. Elas são tomadas para resolver problemas específicos e atender aos requisitos de negócios e técnicos. Para o sistema de gerenciamento de bibliotecas, as principais decisões arquiteturais incluem a escolha de tecnologias, padrões de design e estratégias para diferentes aspectos do sistema.

### 1. Escolha de Tecnologias

#### 1.1. Frontend: React
- **Motivação**: 
  - **React** foi escolhido por sua capacidade de criar interfaces de usuário interativas e responsivas com uma experiência rica e dinâmica.
  - **Componentização**: Permite a criação de componentes reutilizáveis e manutenção mais fácil do código.
  - **Ecosistema**: Suporte robusto de bibliotecas e ferramentas, como **React Router** para roteamento e **Redux** para gerenciamento de estado.

#### 1.2. Backend: .NET Core
- **Motivação**:
  - **.NET Core** foi selecionado por sua performance, escalabilidade e suporte a múltiplas plataformas (Windows, Linux).
  - **Desenvolvimento Rápido**: Fornece um conjunto completo de ferramentas e bibliotecas para desenvolvimento eficiente de APIs.
  - **Suporte a Microserviços**: Facilita a implementação de uma arquitetura baseada em microserviços, se necessário.

#### 1.3. Banco de Dados: MongoDB e MS SQL Server
- **Motivação**:
  - **MongoDB**: Escolhido para armazenar dados não estruturados e documentos, como o acervo de livros, proporcionando flexibilidade e escalabilidade.
  - **MS SQL Server**: Utilizado para armazenar dados estruturados e transacionais, como informações de usuários e empréstimos, oferecendo robustez e suporte a consultas complexas.

### 2. Estratégia de Autenticação e Autorização

#### 2.1. Sessões
- **Motivação**:
  - Em vez de JWT, o sistema utiliza **sessões** geridas pelo backend para autenticação. Sessões são armazenadas e geridas no servidor, simplificando o gerenciamento de estado e evitando o uso de tokens no cliente.

#### 2.2. Controle de Acesso
- **Motivação**:
  - **Controle de Acesso Baseado em Papéis (RBAC)**: Implementado no backend para garantir que apenas usuários autorizados possam acessar ou modificar recursos específicos.

### 3. Arquitetura de Sistema

#### 3.1. Arquitetura de Microserviços vs. Monolítica
- **Decisão**: 
  - **Monolítica**: Optado por uma arquitetura monolítica inicialmente para simplificar o desenvolvimento e a implantação.
  - **Motivação**: Facilidade de desenvolvimento e menor complexidade na gestão de múltiplos serviços e comunicação inter-serviços.

#### 3.2. Escalabilidade
- **Decisão**:
  - **Escalabilidade Horizontal**: O backend é escalável horizontalmente, permitindo adicionar mais instâncias conforme necessário para lidar com aumentos na carga.
  - **Motivação**: Garante que o sistema possa lidar com um número crescente de usuários e requisições.

### 4. Gerenciamento de Estado

#### 4.1. Frontend
- **Decisão**:
  - **Redux** ou **Context API** para gerenciamento de estado global no frontend.
  - **Motivação**: Facilita a gestão do estado da aplicação e a comunicação entre componentes, especialmente em uma aplicação com múltiplos estados e interações complexas.

### 5. Armazenamento de Dados

#### 5.1. Dados Não Estruturados
- **Decisão**:
  - **MongoDB** para dados não estruturados, como o acervo de livros.
  - **Motivação**: Flexibilidade para armazenar dados em formato de documento e facilidade para escalar horizontalmente.

#### 5.2. Dados Estruturados e Transacionais
- **Decisão**:
  - **MS SQL Server** para dados estruturados e transacionais, como informações de empréstimos e usuários.
  - **Motivação**: Suporte a consultas complexas e integridade referencial.

### 6. Deployment e Infraestrutura

#### 6.1. Infraestrutura em Nuvem
- **Decisão**:
  - **AWS** ou **Azure** para hospedagem dos serviços, bancos de dados e infraestrutura.
  - **Motivação**: Escalabilidade, alta disponibilidade e serviços gerenciados que reduzem a complexidade operacional.

#### 6.2. CI/CD
- **Decisão**:
  - **Pipeline de CI/CD** para automação de build, testes e deploy.
  - **Motivação**: Facilita a integração contínua e a entrega contínua, garantindo que as atualizações de código sejam implementadas rapidamente e com qualidade.

### 7. Performance e Escalabilidade

#### 7.1. Cache
- **Decisão**:
  - **Redis** para cache de dados frequentemente acessados.
  - **Motivação**: Reduz a carga nos bancos de dados e melhora o desempenho das consultas.

#### 7.2. CDN
- **Decisão**:
  - **CDN** para servir arquivos estáticos do frontend.
  - **Motivação**: Melhora o tempo de resposta e a experiência do usuário globalmente.

### 8. Monitoramento e Logging

#### 8.1. Monitoramento
- **Decisão**:
  - **Azure Monitor** para monitorar a saúde e o desempenho do sistema.
  - **Motivação**: Garantia de visibilidade e resposta proativa a problemas operacionais.

#### 8.2. Logging
- **Decisão**:
  - **Motivação**: Facilita a detecção e resolução de problemas, além de fornecer insights sobre o comportamento do sistema.


---

# Quality Requierements

## Visão Geral

Os **Quality Requirements** especificam os atributos que o sistema deve possuir para atender às expectativas de desempenho, segurança, usabilidade e outros aspectos críticos. Para o sistema de gerenciamento de bibliotecas, os principais requisitos de qualidade incluem:

1. **Desempenho**
2. **Segurança**
3. **Escalabilidade**
4. **Manutenibilidade**
5. **Usabilidade**
6. **Confiabilidade**
7. **Portabilidade**

### 1. Desempenho

#### Requisitos:
- **Tempo de Resposta**: O sistema deve garantir que a resposta para consultas e ações do usuário ocorra em menos de 2 segundos na maioria das vezes.
- **Taxa de Transferência**: A API deve ser capaz de lidar com até 500 requisições por segundo sem degradação significativa de desempenho.
- **Uso de Recursos**: O uso de CPU e memória pelo backend deve ser monitorado e otimizado para evitar sobrecarga nos servidores.

#### Estratégias:
- **Cache**: Utilização de cache para dados frequentemente acessados.
- **CDN**: Distribuição de arquivos estáticos via CDN para melhorar o tempo de carregamento do frontend.

### 2. Segurança

#### Requisitos:
- **Proteção de Dados**: Dados sensíveis devem ser criptografados tanto em trânsito quanto em repouso.
- **Autenticação e Autorização**: O sistema deve garantir que apenas usuários autenticados e autorizados possam acessar e modificar dados.
- **Proteção contra Ataques**: Implementação de medidas de segurança contra ataques comuns, como SQL Injection, XSS, e CSRF.

#### Estratégias:
- **Controle de Acesso**: Implementação de controle de acesso baseado em papéis (RBAC) e gerenciamento de sessões no backend.

### 3. Escalabilidade

#### Requisitos:
- **Escalabilidade Horizontal**: O sistema deve ser capaz de adicionar novas instâncias de serviços para lidar com aumento na carga.
- **Desempenho em Grande Escala**: O sistema deve manter a performance adequada mesmo com um grande número de usuários e transações simultâneas.

#### Estratégias:
- **Arquitetura Escalável**: Uso de serviços em nuvem e containers para escalabilidade automática.
- **Balanceamento de Carga**: Utilização de balanceadores de carga para distribuir requisições entre múltiplas instâncias.

### 4. Manutenibilidade

#### Requisitos:
- **Facilidade de Atualização**: O sistema deve permitir atualizações e correções de forma eficiente, minimizando o tempo de inatividade.
- **Documentação**: Documentação clara e atualizada para desenvolvedores e administradores do sistema.

#### Estratégias:
- **CI/CD**: Implementação de pipelines de integração e entrega contínua para automação de deploy e testes.
- **Boas Práticas de Código**: Aplicação de princípios de **Clean Code** e padrões de codificação para facilitar a manutenção e evolução do código.

### 5. Usabilidade

#### Requisitos:
- **Interface Intuitiva**: O sistema deve possuir uma interface de usuário intuitiva e fácil de usar para bibliotecários, administradores e leitores.
- **Acessibilidade**: O sistema deve ser acessível para usuários com necessidades especiais, atendendo aos padrões de acessibilidade web (WCAG).

#### Estratégias:
- **Design Responsivo**: Implementação de design responsivo para garantir uma boa experiência em diferentes dispositivos e tamanhos de tela.
- **Testes de Usabilidade**: Realização de testes de usabilidade com usuários reais para identificar e corrigir problemas na interface.

### 6. Confiabilidade

#### Requisitos:
- **Disponibilidade**: O sistema deve ter uma alta disponibilidade, com um tempo de inatividade planejado não superior a 1% ao longo do ano.
- **Recuperação de Falhas**: Capacidade de recuperação rápida em caso de falhas ou interrupções.

#### Estratégias:
- **Monitoramento**: Implementação de ferramentas de monitoramento para detectar e responder a problemas rapidamente.

### 7. Portabilidade

#### Requisitos:
- **Compatibilidade**: O sistema deve ser compatível com diferentes navegadores e sistemas operacionais.
- **Facilidade de Deploy**: O sistema deve poder ser facilmente implantado em diferentes ambientes (desenvolvimento, staging, produção).

#### Estratégias:
- **Containers**: Uso de containers Docker para garantir que o sistema funcione de forma consistente em diferentes ambientes.
- **Testes de Compatibilidade**: Realização de testes de compatibilidade em diferentes navegadores e sistemas operacionais para garantir a portabilidade.

#### Cenários ATAM

### Cenário 1: Sistema de Biblioteca com Alta Demanda de Empréstimos e Consultas

- **Cenário**: Suponha que o sistema de biblioteca tenha alta demanda de empréstimos e consultas durante o período de inscrições e avaliações.
- **Atributos de Qualidade**: Desempenho, escalabilidade, e confiabilidade.
- **Decisão Arquitetural**: Escolha entre uma arquitetura de microserviços e uma arquitetura monolítica.
- **Trade-offs**: A arquitetura de microserviços permite escalabilidade horizontal, o que ajuda o sistema a lidar com picos de uso. Contudo, adiciona complexidade, especialmente no gerenciamento de transações distribuídas. Já a arquitetura monolítica é mais simples para monitorar e gerenciar, mas pode sofrer com problemas de desempenho em alta escala.
- **Resultados**: A arquitetura de microserviços pode apresentar riscos de latência devido à comunicação entre serviços. A arquitetura monolítica, apesar de mais fácil de manter inicialmente, pode exigir reestruturação no futuro para suportar o aumento de carga.

---

### Cenário 2: Biblioteca com Requisitos Rigorosos de Segurança e Privacidade

- **Cenário**: O sistema de biblioteca precisa garantir a proteção de dados pessoais e históricos de leitura, em conformidade com leis de proteção de dados.
- **Atributos de Qualidade**: Segurança, disponibilidade e manutenibilidade.
- **Decisão Arquitetural**: Escolha entre uma arquitetura com autenticação centralizada (baseada em tokens) ou uma abordagem descentralizada, com autenticação distribuída por serviço.
- **Trade-offs**: A autenticação centralizada facilita a gestão de acessos e auditoria, enquanto uma autenticação descentralizada aumenta a resiliência do sistema, caso um serviço seja comprometido. Porém, a descentralização pode tornar mais complexa a atualização de políticas de segurança.
- **Resultados**: A abordagem descentralizada permite maior disponibilidade em caso de ataques a um serviço específico, mas pode ser difícil de manter. A autenticação centralizada simplifica a gestão, mas representa um ponto único de falha.

---

### Cenário 3: Expansão do Sistema de Biblioteca para Diferentes Universidades

- **Cenário**: O sistema de biblioteca é expandido para uso em outras universidades, cada uma com suas regras de empréstimo e tipos de acervo.
- **Atributos de Qualidade**: Portabilidade, escalabilidade, e facilidade de manutenção.
- **Decisão Arquitetural**: Escolha entre manter um único sistema centralizado ou adotar uma abordagem multi-tenant com instâncias para cada universidade.
- **Trade-offs**: Um sistema centralizado facilita a manutenção e atualização de versões, mas pode não ser flexível o suficiente para diferentes regras e políticas. A abordagem multi-tenant garante maior personalização e isolamento entre clientes, mas aumenta a complexidade de manutenção e o uso de recursos.
- **Resultados**: A abordagem multi-tenant reduz o risco de interferências entre clientes e permite customizações. A solução centralizada é mais econômica em recursos, mas dificulta adaptações para requisitos específicos de cada universidade.


---

# Risk and Technical Debt

## Visão Geral

**Risk and Technical Debt** são aspectos críticos a serem geridos durante o desenvolvimento e operação do sistema de gerenciamento de bibliotecas. **Riscos** representam potenciais problemas que podem impactar negativamente o projeto, enquanto **dívidas técnicas** referem-se a compromissos feitos durante o desenvolvimento que podem criar desafios futuros.

### 1. Riscos

#### 1.1. Riscos Técnicos

- **Integração com Tecnologias de Terceiros**:
  - **Descrição**: A integração com serviços externos (como APIs de terceiros) pode ser afetada por mudanças na API, problemas de compatibilidade, ou descontinuação do serviço.
  - **Mitigação**: Realizar testes rigorosos e monitorar atualizações dos serviços externos. Estabelecer acordos de nível de serviço (SLAs) com fornecedores, se possível.

- **Complexidade da Arquitetura**:
  - **Descrição**: A escolha de uma arquitetura monolítica pode criar dificuldades na escalabilidade e na implementação de novas funcionalidades.
  - **Mitigação**: Planejar uma possível migração para uma arquitetura de microserviços conforme o sistema cresce. Documentar a arquitetura e realizar revisões periódicas.

- **Segurança**:
  - **Descrição**: Vulnerabilidades de segurança podem ser exploradas por atacantes, comprometendo dados e serviços.
  - **Mitigação**: Implementar práticas de segurança robustas, como criptografia, autenticação forte, e realizar auditorias de segurança regulares.

- **Desempenho e Escalabilidade**:
  - **Descrição**: O sistema pode enfrentar problemas de desempenho e escalabilidade conforme o número de usuários e dados cresce.
  - **Mitigação**: Realizar testes de carga e estresse para identificar e resolver problemas de desempenho. Implementar estratégias de cache e escalabilidade.

#### 1.2. Riscos Operacionais

- **Falhas de Infraestrutura**:
  - **Descrição**: Problemas com servidores ou serviços de nuvem podem afetar a disponibilidade do sistema.
  - **Mitigação**: Utilizar serviços de nuvem com alta disponibilidade e configurar estratégias de recuperação de desastres. Monitorar a infraestrutura e realizar backups regulares.

- **Gerenciamento de Dependências**:
  - **Descrição**: Dependências externas podem ter versões desatualizadas ou vulneráveis que afetam o sistema.
  - **Mitigação**: Manter dependências atualizadas e realizar verificações de vulnerabilidades regularmente. Usar ferramentas de gerenciamento de dependências para automatizar o processo.

### 2. Dívidas Técnicas

#### 2.1. Código e Design

- **Código Legado**:
  - **Descrição**: Código escrito rapidamente para cumprir prazos pode ser difícil de manter e expandir.
  - **Mitigação**: Refatorar o código regularmente e aplicar práticas de **Clean Code**. Estabelecer revisões de código e padrões de codificação.

- **Falta de Testes Automatizados**:
  - **Descrição**: A ausência de testes automatizados pode resultar em falhas não detectadas e dificuldades para realizar mudanças no código.
  - **Mitigação**: Investir na criação de uma suíte de testes automatizados e incluir testes unitários, de integração e end-to-end no pipeline de CI/CD.

#### 2.2. Documentação

- **Documentação Insuficiente**:
  - **Descrição**: Documentação inadequada pode dificultar a manutenção e a compreensão do sistema por novos desenvolvedores.
  - **Mitigação**: Manter documentação técnica atualizada e abrangente. Incluir documentação de arquitetura, design e APIs.

- **Falta de Documentação de Processo**:
  - **Descrição**: A falta de documentação sobre processos e decisões pode levar a uma má comunicação e execução inconsistente.
  - **Mitigação**: Documentar processos de desenvolvimento, padrões de codificação e decisões arquiteturais importantes.

#### 2.3. Ferramentas e Infraestrutura

- **Ambientes de Desenvolvimento Desatualizados**:
  - **Descrição**: Ferramentas e ambientes desatualizados podem causar incompatibilidades e problemas de desenvolvimento.
  - **Mitigação**: Atualizar regularmente as ferramentas de desenvolvimento e manter ambientes de desenvolvimento consistentes com a produção.

- **Problemas de Integração Contínua/Entrega Contínua**:
  - **Descrição**: Falhas na configuração ou manutenção dos pipelines de CI/CD podem atrasar o desenvolvimento e a entrega.
  - **Mitigação**: Monitorar e testar continuamente os pipelines de CI/CD. Resolver problemas rapidamente e manter a configuração dos pipelines atualizada.

