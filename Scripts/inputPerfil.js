var link

function retorno(linkFunc) {
    var nome = document.getElementById('nomeTxt')
    var nomeFant = document.getElementById('nomeFantTxt')
    var cpf = document.getElementById('cpfTxt')
    var carteiraProd = document.getElementById('carteiraProdTxt')
    var cnpjCoop = document.getElementById('cnpjCoopTxt')
    var cnpjJur = document.getElementById('cnpjJurTxt')

    if (cpf.value == "" && carteiraProd.value == "") {
        cpf.style.display = "none"
        carteiraProd.style.display = "none"
        nome.style.display = "none"
        cnpjJur.style.display = "none"

        linkFunc = "/html/homeCoop.html"
        link = linkFunc

        alert('Redirecionar para homeCoop')

        return link()
    } if (carteiraProd.value != "") {
        nomeFant.style.display = "none"
        cnpjCoop.style.display = "none"
        cnpjJur.style.display = "none"

        linkFunc = "/html/homeProdutor.html"
        link = linkFunc

        alert('Redirecionar para homeProdutor')

        return link()
    } else {
        nomeFant.style.display = "none"
        carteiraProd.style.display = "none"
        cnpjCoop.style.display = "none"
        cnpjJur.style.display = "none"

        linkFunc = "/html/home.html"
        link = linkFunc

        alert('indo pra home client')

        return link()
    }
}

function pagAnterior(linkAnt) {
    linkAnt = link
    window.location.replace(`${linkAnt}`)
}