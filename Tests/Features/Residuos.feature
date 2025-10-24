Feature: Gerenciamento de Resíduos
  Como um usuário da API de Gestão de Resíduos
  Quero poder cadastrar, consultar, atualizar e excluir resíduos
  Para manter o controle do descarte e reciclagem

  Background:
    Given que a API está em execução no endereço "http://localhost:8080/api/residuos"

  Scenario: Cadastrar um novo resíduo com sucesso
    When eu envio uma requisição POST com os seguintes dados:
      | nome     | tipo         |
      | Plástico | Reciclável   |
    Then o sistema deve retornar status code 201
    And o corpo da resposta deve conter o campo "idResiduo"
    And o campo "nome" deve ser igual a "Plástico"

  Scenario: Tentar cadastrar um resíduo com dados inválidos
    When eu envio uma requisição POST com os seguintes dados:
      | nome | tipo |
      | ""   | ""   |
    Then o sistema deve retornar status code 400
    And o corpo da resposta deve conter uma mensagem de erro

  Scenario: Consultar todos os resíduos cadastrados
    When eu envio uma requisição GET para listar todos os resíduos
    Then o sistema deve retornar status code 200
    And o corpo da resposta deve conter uma lista de resíduos

  Scenario: Consultar um resíduo pelo ID existente
    Given que existe um resíduo com ID 1
    When eu envio uma requisição GET para /api/residuos/1
    Then o sistema deve retornar status code 200
    And o corpo da resposta deve conter o campo "idResiduo"

  Scenario: Atualizar um resíduo existente
    Given que existe um resíduo com ID 1
    When eu envio uma requisição PUT para /api/residuos/1 com os seguintes dados:
      | nome     | tipo         |
      | Vidro    | Reciclável   |
    Then o sistema deve retornar status code 204

  Scenario: Excluir um resíduo inexistente
    When eu envio uma requisição DELETE para /api/residuos/999
    Then o sistema deve retornar status code 404
