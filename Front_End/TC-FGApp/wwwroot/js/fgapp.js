function NumeroFormatado(value) {
    value = value.toFixed(0);
    value = value.toString();
    value = value.split(/(?=(?:...)*$)/);

    value = value.join('.');
    return value;
}