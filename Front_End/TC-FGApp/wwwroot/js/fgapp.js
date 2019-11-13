function NumeroFormatado(value) {
    value = value.toString();
    value = value.split(/(?=(?:...)*$)/);

    value = value.join('.');
    return value;
}