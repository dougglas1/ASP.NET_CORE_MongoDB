:brazil:

### **Orientações**

Versão: net5.0

Tenha o Docker instalado.

Baixe a Imagem do MongoDB: ```docker pull mongo```

Inicie um container com a imagem: ```docker run --name mongodb -p 27017:27017 -e MONGO_INITDB_ROOT_USERNAME=douglas -e MONGO_INITDB_ROOT_PASSWORD=123456 mongo```

Outra opção é utilizar o serviço: MongoDB Atlas

### **Melhorias a serem feitas**

- Trabalhar com objeto/lista dentro do "People".
- Efetuar alteração no "Builder" para consultar o objeto/lista dentro do "People".
- Ajustar para que a consulta não tenha diferença entre maíuscula e mínuscula, é possível com Aggregate, mas não ficou legal a legibilidade do código.
- Ajustar Paginated para que seja efetuada somente uma consulta (count e find), é possível com Aggreate + Facet, porém não consegui atribuir a expressão "Selector" para retornar somente o necessário.
- Ajustar Paginated para que seja possível efetuar a ordenação, minha ideia é utilizar "Column" e "Order" do "FilterBase", porém ainda sem sucesso de forma genérica.
- No MongoDB tem a transação e não foi utilizado no código já que não tem mais de 1 insert em diferentes documentos, seria interessante ter um código apresentando seu funcionamento.
- Criar testes unitários / integração com xUnit ou nUnit.
