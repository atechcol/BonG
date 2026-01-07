# Design

### Logik
- Lagre varer i `Dictionary`.
    - Måske skal vi serialisere?
- Tjek om stregkode er misdannet
    - Vi antager, at 
vinflaskerne bruger GTIN-13. Ellers kan det abstraheres.
#### Format til indkøb

| Felt        | Beskrivelse                           |
| ----------- | ------------------------------------- |
| Dato        | Hvornår indkøbet skete, med tidspunkt |
| Produkter   | Hvilke produkter der blev købt        |
| Samlet pris | Summen af de købte produkters pris    |

```yaml

purchases:
    1:
        timestamp: 2026-08-01 11:57:32
        products:
            - product:
                name: "John Chardonnay"
                price: 250.00
                barcode: [0, 12345678912, 4]
              quantity: 4
            - product:
                name: "Børge Rødvin"
                price: 309.95
                barcode: [0, 21324354657, 2]
              quantity: 2
        total: 1619.9
    2:
        ...

```