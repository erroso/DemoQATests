# DemoQATests


- Objetivo é testar o www.demoqa.com/Books

- Não há branches além do raiz. Se isso fosse um projeto real de teste, provavelmente a organização dos branches seguiriam a mesma organização da aplicação.

- Principais frameworks usados: Specflow, Selenium, Restsharp, xUnit, FluentAssertions e PageObjects.

- Instalação: Baixe o código e abra o "DemoQATests.sln" através do Visual Studio (o Visual Studio vai baixar todas as dependências do projeto). Uma vez baixado todas as dependências, compile o projeto e depois rode os testes pela janela de "Test Explorer".

- Cenários de testes: Os testes estão descritos usando a abordagem BDD e podem serem vistos nos arquivos dentro da pasta "Features" e os passos (Steps) que operalizam os cenários estão implementados na pasta "Steps".

- Como estamos usando o padrão Page Objects então as classes dentro da pasta "PageObjects" fazem o mapeamento dos atributos e comportamentos necessários manipular as páginas. Cada página tem um arquivo específico.
