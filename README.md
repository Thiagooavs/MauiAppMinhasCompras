# MauiAppMinhasCompras

<div align="center">
  <img src="/api/placeholder/200/200" alt="Logo do Aplicativo" />
  <h3>Seu Assistente de Compras Pessoal</h3>
</div>

## 📋 Visão Geral

**MauiAppMinhasCompras** é um aplicativo multiplataforma desenvolvido com **.NET MAUI** (Multi-platform App UI), permitindo que usuários gerenciem suas listas de compras de forma simples e eficiente. O aplicativo funciona em dispositivos Android, iOS, Windows e macOS a partir de uma única base de código.

## 🚀 Tecnologias Utilizadas

- **Linguagem Principal**: C# (.NET 7.0)
- **Framework**: .NET MAUI
- **Armazenamento de Dados**: SQLite
- **Padrão de Arquitetura**: MVVM (Model-View-ViewModel)

## ⚙️ Funcionalidades

- Criação e gerenciamento de múltiplas listas de compras
- Adição, edição e remoção de itens
- Marcação de itens como comprados
- Cálculo automático do valor total da compra
- Interface intuitiva com design responsivo
- Funcionamento offline (sem necessidade de internet)

## 📱 Compatibilidade

- Android 7.0 ou superior
- iOS 14.0 ou superior
- Windows 10/11
- macOS 11.0 ou superior

## 🔧 Instalação e Uso

### Pré-requisitos
- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) com cargas de trabalho para desenvolvimento móvel
- Para desenvolvimento iOS: macOS com Xcode instalado

### Passos para Executar o Projeto

1. Clone o repositório:
```bash
git clone https://github.com/Thiagooavs/MauiAppMinhasCompras.git
```

2. Abra a solução no Visual Studio 2022
3. Selecione a plataforma de destino desejada
4. Pressione F5 para compilar e executar o aplicativo

## 🧩 Estrutura do Projeto

```
MauiAppMinhasCompras/
├── Models/              # Classes de modelo de dados
├── ViewModels/          # Classes de ViewModel (MVVM)
├── Views/               # Páginas XAML da interface
├── Services/            # Serviços de acesso a dados
├── Resources/           # Recursos gráficos e estilos
└── Platforms/           # Código específico por plataforma
```

## 📊 Detalhes da Implementação

O aplicativo implementa o padrão MVVM (Model-View-ViewModel) para separar a lógica de negócios da interface do usuário. O SQLite é utilizado como banco de dados local para armazenar as listas de compras e seus itens.

A interface é construída com XAML, aproveitando os recursos do .NET MAUI para criar uma experiência de usuário consistente em todas as plataformas suportadas.

## 🤝 Contribuições

Contribuições são bem-vindas! Se você quiser melhorar este aplicativo, sinta-se à vontade para fazer um fork do repositório e enviar um pull request.

## 📄 Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

## 📞 Contato

Para dúvidas ou sugestões, entre em contato através do GitHub: [@Thiagooavs](https://github.com/Thiagooavs)

---

<div align="center">
  <p>Desenvolvido com ❤️ usando .NET MAUI</p>
</div>
