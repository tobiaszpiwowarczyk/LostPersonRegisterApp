/*
 * Klasa przechowująca dane odnośnie typu okienka dialogowego.
 */
export default class ModalData {

    /*
     * @iconName - nazwa ikony, która będzie wyświetlała się w nagłówku okna dialogowego
     * @color    - kolor, który ma zaakcentować typ okna dialogowego
     * @title    - tekst, który się wyświetli w nagłówku okna dialogowego
     */
    constructor(iconName, color, title) {
        this.iconName = iconName;
        this.color = color;
        this.title = title;
    }
}