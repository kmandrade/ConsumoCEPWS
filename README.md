# ConsumoCEPWS

Tutorial para consumo de WebServices.

WebService dos Correios para obter informações do endereço cujo o CEP for informado.

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
