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
    - timestamp: 2026-08-01 11:57:32
      products:
          - product:
              name: "John Chardonnay"
              price: 250.00
              barcode:
                  indicator: 0 
                  company-item: 21324354657
                  check: 2
              quantity: 4
          - product:
              name: "Børge Rødvin"
              price: 309.95
              barcode: 
                  indicator: 0 
                  company-item: 21324354657
                  check: 2
              quantity: 2
          total: 1619.9

    - timestamp: 2026-08-01 12:32:12
      products:
          - product:
              name: "Børge Rødvin"
              price: 683.95
              barcode:
                  indicator: 0 
                  company-item: 21324354657
                  check: 2
              quantity: 1
          total: 683.95

```