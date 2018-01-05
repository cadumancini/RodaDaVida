using RodaDaVidaShared.Tabelas;

namespace RodaDaVidaShared.Utils
{
    public class Utils
    {
        public static Utils current;
        public double NotasPorTarefa = 1.0;

        private Utils()
        {

        }

        public static Utils Current
        {
            get
            {
                if (current == null)
                    current = new Utils();

                return current;
            }
        }

        public string GetMensagem(Area area)
        {
            string mensagem = "";

            switch (area.Codigo)
            {
                case 1: //Familiar
                    mensagem = "Vamos definir sua nota na área " + area.Descricao + ". \n\n" +
                                "Você está dando a atenção que sua família precisa? \n" +
                                "Tem conversado com seus filhos? \n" +
                                "Tem visitado seus familiares mais próximos? \n" +
                                "Tem se relacionado bem com as pessoas que você ama? \n" +
                                "Como é o relacionamento com seus pais? Com seus irmãos? \n" +
                                "Você é um(a) pai/mãe atencioso(a)? \n" +
                                "Você pode fazer mais pela felicidade da sua família? \n\n" +
                                "Baseado nesses questionamentos, qual é a sua nota na área " + area.Descricao + "?";
                    break;
                case 2: //Profissional
                    mensagem = "Vamos definir sua nota na área " + area.Descricao + ". \n\n" +
                                "Você está satisfeito com seu emprego? \n" +
                                "Está fazendo o que gosta? \n" +
                                "Acorda motivado para trabalhar? \n" +
                                "Sente-se realizado com as tarefas que tem? \n" +
                                "Como você se sente em relação aos seus resultados? \n" +
                                "Você tem um plano de crescimento profissional? \n\n" +
                                "Baseado nesses questionamentos, qual é a sua nota na área " + area.Descricao + "?";
                    break;
                case 3: //Saude
                    mensagem = "Vamos definir sua nota na área da " + area.Descricao + ". \n\n" +
                                "Como está tua saúde? \n" +
                                "Você faz exames médicos regularmente? \n" +
                                "Tem uma alimentação balanceada? \n" +
                                "Você consegue controlar os excessos: bebida, cigarro, remédios, entre outros? \n" +
                                "Você atua preventivamente em relação à tua saúde? \n\n" +
                                "Baseado nesses questionamentos, qual é a sua nota na área da " + area.Descricao + "?";
                    break;
                case 4: //Fisica
                    mensagem = "Vamos definir sua nota na área " + area.Descricao + ". \n\n" +
                                "Você tem praticado alguma atividade física regularmente? \n" +
                                "Você se sente tranquilo fisicamente ao fazer uma atividade mais ritimada? \n" +
                                "Você tem conseguido manter o peso ideal? \n" +
                                "Tem feito algo pela moradia do teu espírito? \n\n" +
                                "Baseado nesses questionamentos, qual é a sua nota na área " + area.Descricao + "?";
                    break;
                case 5: //Financeira
                    mensagem = "Vamos definir sua nota na área " + area.Descricao + ". \n\n" +
                                "Está satisfeito com sua renda atual? \n" +
                                "Você consegue controlar sua planilha de gastos e receitas? \n" +
                                "Tem um planejamento de despesas? \n" +
                                "Você tem feito alguma coisa diferente para melhorar? \n\n" +
                                "Baseado nesses questionamentos, qual é a sua nota na área " + area.Descricao + "?";
                    break;
                case 6: //Economica
                    mensagem = "Vamos definir sua nota na área " + area.Descricao + ". \n\n" +
                                "Você economiza quanto por mês? \n" +
                                "Tem plano de Previdência Privada? \n" +
                                "Seu patrimônio tem aumentado ao longo da vida? Quantos por cento ao ano? \n" +
                                "Já pensou em independência financeira? \n\n" +
                                "Baseado nesses questionamentos, qual é a sua nota na área " + area.Descricao + "?";
                    break;
                case 7: //Educação
                    mensagem = "Vamos definir sua nota na área da " + area.Descricao + ". \n\n" +
                                "Você investe na tua própria educação ou espera apenas pela tua empresa? \n" +
                                "Quantos livros você lê por ano? \n" +
                                "Quantos leu no último ano? \n" +
                                "Você participa de cursos e palestras voluntariamente? \n" +
                                "Você faz o necessário para aprender coisas novas ou aguarda pelos outros? \n\n" +
                                "Baseado nesses questionamentos, qual é a sua nota na área da " + area.Descricao + "?";
                    break;
                case 8: //Social
                    mensagem = "Vamos definir sua nota na área " + area.Descricao + ". \n\n" +
                                "Tem tirado um tempo para sair com os amigos? \n" +
                                "Tem visitado parentes e amigos? \n" +
                                "Você participa de associações empresariais, de classe, clubes, etc.? \n\n" +
                                "Baseado nesses questionamentos, qual é a sua nota na área " + area.Descricao + "?";
                    break;
                case 9: //Espiritual
                    mensagem = "Vamos definir sua nota na área " + area.Descricao + ". \n\n" +
                                "Você dedica um tempo para alimentar seu espírito? \n" +
                                "Tem frequentado sua igreja? \n" +
                                "Tem meditado, feito orações? \n" +
                                "Tem lido a Bíblia? \n\n" +
                                "Baseado nesses questionamentos, qual é a sua nota na área " + area.Descricao + "?";
                    break;
                case 10: //Comunidade
                    mensagem = "Vamos definir sua nota na área da " + area.Descricao + ". \n\n" +
                                "Dedica algum tempo para trabalhos voluntários? \n" +
                                "Tem feito algo pelo teu bairro? E pela tua cidade? \n" +
                                "Você participa da associação do seu bairro? \n\n" +
                                "Baseado nesses questionamentos, qual é a sua nota na área da " + area.Descricao + "?";
                    break;
                case 11: //Ecologica
                    mensagem = "Vamos definir sua nota na área " + area.Descricao + ". \n\n" +
                                "O que você tem feito pela preservação ambiental? \n" +
                                "Quanto tempo você leva no banho? \n" +
                                "Fecha a torneira enquanto escova os dentes? \n" +
                                "Separa o lixo? \n" +
                                "Você é dependente do automóvel? \n\n" +
                                "Baseado nesses questionamentos, qual é a sua nota na área " + area.Descricao + "?";
                    break;
                case 12: //Lazer
                    mensagem = "Vamos definir sua nota na área do " + area.Descricao + ". \n\n" +
                                "Tem dedicado um tempo para você mesmo? \n" +
                                "Você fez algo diferente quando tira férias? \n" +
                                "Quando foi a última vez que foi ao cinema? \n" +
                                "Baseado nesses questionamentos, qual é a sua nota na área do " + area.Descricao + "?";
                    break;
            }

            return mensagem;
        }
    }
}
