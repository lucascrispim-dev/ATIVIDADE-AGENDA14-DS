# Hotel Horizonte — App Hotel (.NET MAUI)

Atividade da **Agenda 13 – Imagens e Componentes Diversos de Interface Gráfica**
(Desenvolvimento de Sistemas II – Técnico em Desenvolvimento de Sistemas).

**Desenvolvedor:** Lucas Crispim da Silva Rodrigues · **Ano:** 2026

## Telas

| Tela | O que faz |
|---|---|
| **Cálculo da Diária** (`Views/ContratacaoHospedagem`) | Imagem do hotel, `Stepper` para adultos/crianças (valor exibido via `BindingContext="{x:Reference ...}"`), `Picker` com as suítes e `DatePicker` de check-in/check-out com datas mínimas e máximas. |
| **Hospedagem Contratada** (`Views/HospedagemContratada`) | Resumo da reserva. Recebe o objeto `Hospedagem` pelo `BindingContext` e mostra diárias, valor por diária e total. |
| **Sobre** (`Views/Sobre`) | Nova tela com logo, nome do desenvolvedor, ano, curso, disciplina e tecnologias. Aberta pelo botão **Sobre** da tela inicial. |

## Personalizações em relação ao material

- Tema "Hotel Horizonte": paleta azul-marinho e dourado, imagens próprias (fachada e logo em SVG), ícone e splash novos.
- Cartões com `Border` arredondado e estilos reutilizáveis em `App.xaml` (`CartaoHotel`, `TituloCartao`).
- Lista de suítes (`Models/Quarto`) com valores de diária e cálculo do total (`Models/Hospedagem`).
- Valores em R$ e datas no padrão brasileiro (cultura pt-BR).

## Agenda 14 — Orientação a objetos, validação e novo design (v1.1)

- **Encapsulamento com get/set:** `Models/Quarto` e `Models/Hospedagem` usam campos privados e validam os dados no `set`, lançando `ArgumentException` (ex.: diária negativa, check-out antes do check-in, nenhum adulto).
- **Construtor e método:** `Quarto` tem construtor com parâmetros e o método `CalcularDiaria(adultos, criancas)`; `Hospedagem.ValidarCapacidade()` impede reservar mais hóspedes do que a suíte comporta.
- **Array de objetos (`List<Quarto>`):** 5 suítes com preço, capacidade e descrição, usadas pelo Picker e pela nova tela.
- **Validação dos DatePicker:** check-in de hoje até 1 mês; check-out a partir do dia seguinte ao check-in (até 6 meses), com contador de noites em tempo real.
- **Nova tela "Nossas Suítes"** (`Views/NossasSuites`): lista as suítes em `CollectionView`; ao tocar em uma, ela volta selecionada no Picker.
- **Novas cores:** paleta tropical verde-petróleo `#0F5257` + coral `#D1603D` sobre fundo areia `#FAF3EA` (antes azul-marinho e dourado), aplicada também ao logo, ícone e imagem do hotel.

Capturas da execução: `capturas_agenda14/` (e `capturas_agenda14.zip`).

## Como executar

Abra `MauiAppHotel.sln` no Visual Studio 2022 (workload .NET MAUI) e execute em **Windows Machine** ou em um emulador Android.

As capturas da tela Sobre estão em `capturas_tela_sobre/` (e compactadas em `capturas_tela_sobre.zip`).
