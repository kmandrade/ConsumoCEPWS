# ConsumoCEPWS

<h1>Consumo de Serviço WCF e Web Service para Detalhes de Endereço com Cache em Memória</h1>
Este projeto é uma demonstração de como consumir um serviço WCF (Windows Communication Foundation) e um Web Service para obter detalhes de endereço usando a API dos Correios. A implementação utiliza a arquitetura Model-View-Controller (MVC) para criar uma aplicação web que facilita a busca de informações de endereço a partir de um CEP fornecido pelo usuário.

Para conseguir acessar as classes do serviço em questão é necessário adicionar o link do serviço ao seu projeto, conforme as imagens a baixo:
<div style="display: flex; justify-content: space-between;">
    <img src="/ImgsTutorial/1.png" alt="Imagem 1" width="45%">
    <img src="/ImgsTutorial/2.png" alt="Imagem 2" width="45%">
</div>

Após obter um sucesso na conexão com o serviço, você irá instânciar para a classe que desejar no seu projeto a classe referente ao método que desejar
nesse exemplo foi usado para buscar detalhes do endereço a partir de um CEP:
 ```
  var modelCorreios = new AtendeClienteClient();
  var endereco = await modelCorreios.consultaCEPAsync(cep);
```
Para mais detalhes conferir neste projeto como foi feita a implementação.
Foi utilizado também o uso de chace em memória para melhorar o tempo de resposta, especialmente em consultas de CEPs idênticos.
