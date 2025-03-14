using educae.contas.domain.enums;
using educae.contas.domain.ValueObject;
using EstartandoDevsCore.ValueObjects;

namespace educae.contas.domain;

public class Educador : Usuario
{
    public Cpf CPF { get; set; }
    
    protected Educador() {}

    public Educador(string nome, Login login, TipoUsuario tipoUsuario, Cpf cpf) 
    {
        AtribuirNome(nome);
        AtribuirLogin(Login);
        AtribuirTipoUsuario(tipoUsuario);
        CPF = cpf;
    }
    
    public void AtribuirCpf(string cpf) => CPF = new Cpf(cpf);
    
}