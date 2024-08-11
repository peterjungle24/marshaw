//Don't read this with Github, it's rubbish because there's no way to collapse ``#region``
//unless you can read it, good luck

#region Modding notes (again)

#region Noted lol

#region Sintaxes

#region Sintaxes
/*

    [ orig ] coisa de origem do hook
    [ self ] é uma coisa que serve para poder referenciá-la a mesma coisa para um hook
    [ base ] refere-se a qualquer coisa que uma classe base possa acessar. ou seja, uma base!
    [ this ] refere a qualquer coisa que a classe atual possa acessar e também inclui o conteúdo da classe base
    [  ||  ] singifica [ or ] como em GML 
    [  &&  ] singinica [ and ] como em GML
    [  ?   ] sla
    [  !   ] significa [ not ] como em GML, usado quando é o oposto.
    [      ]

*/
#endregion
#region Keywords
/*

  [ string ]      te deixa escrever texto. ---- "oi"          
  [ int ]         te deixa escrever numero inteiro. ---- 82
  [ float ]       te deixa escrever algo com.. [ f ]...? ---- 82f
  [ double ]      te deixa escrever numero decimal. ---- 82.2
  [ char ]        te deixa escrever só uma letra. QUAL UTILIDADE?? ---- 'PO'
  [ var ]         deixa uma variável que de alguma forma, descobre o tipo dele. Oculta isso do compilador, e claro, o GML já faz isso automaticamente. ---- var myVar = 34;
  [ dynamic ]     deixa uma variável que possa ser guardado de alguma forma. tipo, o compilador irá literal ignorar isso, e se tu colocou algo de errado aqui, tu se fudeu.
  [ public ]      deixa público (piada boa), mas fora as piadas, te deixa acessar no namespace inteiro.
  [ private ]     deixa privado (que legal hein.), mas fora as piadas, só pode ser acessado na mesma classe.

*/
#endregion

#endregion
#region Delegates
/*

Se você vir o termo Callback sendo usado, isso está se referindo a um delegado
Você cria um delegado usando a palavra-chave delegado na frente de um formato de método sem colchetes.

Os delegados não têm um corpo de classe. 
Eles apenas definem uma assinatura de método para a qual você pode definir objetos que armazenam identificadores de método que possuem a mesma assinatura de método.


Ambos são métodos válidos de atribuição.

handler = SomeMethod; //Sem parênteses aqui
handler += SomeMethod;

Seu manipulador será nulo até que você coloque algo nele. Tenha cuidado ao tentar invocar seu delegado quando ele estiver vazio.



Ah, e um identificador é um termo do programador para uma referência/ponteiro.
Quando você cria um objeto com um delegado como tipo, esse objeto armazena identificadores que apontam para métodos (instruções no código) que compartilham o mesmo formato (assinatura) do delegado.
Você também pode pensar em uma alça como algo em que você se agarra. Pense nessa ideia, mas em um sentido abstrato.


*/
#endregion
#region delegates 2.0
/*

Um delegado é um tipo que representa referências a métodos com uma lista de parâmetros e tipo de retorno específicos.
você pode associar sua instância a qualquer método com assinatura e tipo de retorno compatíveis
Você pode chamar o método por meio da instância delegada

Delegados são usados ​​para passar métodos como argumentos para outros métodos. Os manipuladores de eventos nada mais são do que métodos invocados por meio de delegados. 
Você cria um método personalizado e uma classe como um controle do Windows pode chamar seu método quando ocorre um determinado evento.


public delegate string GeneralCreatures("Lizards", "Centipedes");


Qualquer método de qualquer classe ou estrutura acessível que tenha o mesmo tipo delegado pode ser usado ao delegado. PO método pode ser estático ou de instância. 
Essa flexibilidade deixa você pode alterar programaticamente as chamadas de método ou inserir novo código em classes existentes.


No contexto de sobrecarga de método, a assinatura de um método não inclui o valor de retorno. 
Mas no contexto dos delegados, a assinatura inclui o valor de retorno. Em outras palavras, um método deve ter o mesmo tipo de retorno que o delegado.


 ---- Os delegados permitem que métodos sejam passados ​​como parâmetros.
 ---- Delegados podem ser usados ​​para definir métodos de retorno de chamada.
 ---- Os delegados podem ser encadeados; por exemplo, vários métodos podem ser chamados em um único evento.
 ---- Os métodos não precisam ser iguais ao tipo de delegado.
 ---- Expressões lambda são uma forma mais concisa de escrever blocos de código embutidos. Expressões lambda (em determinados contextos) são compiladas para delegar tipos



*/
#endregion
#region delegates 3.0
/*

 ---- Como definir um delegado
 ---- Qual será a aparência da assinatura do método do seu delegado definido
 ---- Como armazenar identificadores de método em um “manipulador”
 ---- Como invocar seu manipulador

Você não precisa de uma classe especial, a menos que precise armazenar referências estáticas aos delegados do seu programa.


Isso cria um tipo delegado com o nome Callback que não retorna nada e possui uma string para o argumento. PO nome usado como argumento não tem sentido. Isso não muda a forma como o delegado funciona.
Delegados gostam desta função de forma semelhante às classes. Seu delegado se torna um tipo que você usa para variáveis ​​e declarações de campo.

PO código de exemplo definiu um delegado chamado Callback. PO exemplo então criou uma variável chamada handler com o nome do tipo Callback.

//create a delegate
public delegate void Callback(string message);

//create a method for the delegate
public static void DelegateMethod(string message)
{
    Console.WriteLine(message);
}

//instance the delegate
Callback handler = DelegateMethod;

//call the method
handler("Hello World");


PO exemplo mostra que você pode armazenar um método com a assinatura definida pelo delegado em que está sendo colocado, ou seja, um método que não retorna nada e lida com exatamente uma string.

 ---- PO nome do método deste método não importa
 ---- PO modificador de acesso não deveria importar. Você pode colocar um privado, público, protegido? método em um delegado. Se quebrar para você me avise.
 ---- PO nome do argumento não importa.
 ---- Método pode ser um estático ou não estátco.


*/
#endregion
#region delegates 4.0
/*

Você não precisa criar delegados personalizados. A Microsoft forneceu alternativas capazes de armazenar qualquer assinatura de método desejada.

Action<digite aqui>
Usado para métodos que não retornam nada. Colchetes angulares são para os argumentos. Deixe-os de fora se não houver argumentos.
{
    
    Action<int> handler;
    Isso pega qualquer identificador de método que não retorne nada e tenha um argumento int.
    
}

Formatação de colchete angular
Vários tipos são separados por vírgulas entre colchetes `<type1, type2, type3>

Func<return type, argument type>
Usado para métodos que retornam algo. Você deve usar colchetes angulares para um Func.
{
    
    Func<bool, string, float> handler;
    Isso pega qualquer identificador de método que retorne um bool e tenha um argumento de string seguido por um argumento float.
    
}

(NOTA: RETURN TYPES DEVERAO ESTAR NO FINAL)

*/
#endregion
#region Singatures
/*

uma assinatura de método refere-se ao nome e aos parâmetros de um método

public void method(string, int)
{

    

}


public - modificador de acesso
void - tipo de retorno
method name + arguments - assinatura

*/
#endregion
#region Events
/*

Os eventos permitem que uma classe ou objeto notifique outras classes ou objetos quando algo de interesse ocorre. 
A classe que envia (ou gera ) o evento é chamada de editor e as classes que recebem (ou tratam ) do evento são chamadas de assinantes

 ---- PO editor determina quando um evento é gerado; os assinantes determinam que ação será tomada em resposta ao evento.
 ---- Um evento pode ter vários assinantes. Um assinante pode lidar com vários eventos de vários editores.
 ---- Eventos que não têm assinantes nunca são gerados.
 ---- Os eventos normalmente são usados ​​para sinalizar ações do usuário, como cliques em botões ou seleções de menu em interfaces gráficas de usuário.
 ---- Quando um evento tem vários assinantes, os manipuladores de eventos são invocados de forma síncrona quando um evento é gerado. Para invocar eventos de forma assíncrona.
 ---- Na biblioteca de classes .NET, os eventos são baseados no delegado EventHandler e na classe base EventArgs.



*/
#endregion
#region Event Handling
/*

EventHandler é um delegado que recebe um remetente de objeto e um objeto EventArgs.
EventArgs é apenas uma classe que contém campos relacionados ao evento que um assinante deseja tratar.

Os exemplos tendem a escrever uma mensagem quando um evento é acionado

delegados/eventos/eventhandlers podem ser chamados como métodos normais.

Mas tendo a preferir invocá-los, o que é a mesma coisa


Você pode usar Invoke on Action, Func, EventHandler, qualquer delegado personalizado que você criar =

 [ Invoke ]  ---- 
 [ Action ]  ---- 
 [ Func   ]  ---- 
 [ EventHandler ]  ---- 

                                                --------|       |--------

public class ClassA
{
      public void OnEventTrigger()
      {
          Console.WriteLine("Event happened");
      }
}

public class ClassB
{
    public event Action ev_trigger;

    //Activate ev_trigger
    public TriggerEvent()
    {
      ev_trigger?.Invoke();
    }
}

public static class ClassC
{
    public static Main()
  {
    ClassA A = new ClassA();
    ClassB B = new ClassB();

    //Subscribe ClassA event delegate to ev_trigger
    B.ev_trigger += A.OnEventTrigger;

    DoSomething(B);
  }

  //Send ClassB to a method, so that it cannot access ClassA anymore
  public static DoSomething(ClassB B)
  {
      //Arbitrary code here
      //Activate event
      B.TriggerEvent();
  }
}

PO resultado:

 ---- PO método OnEventTrigger definido em ClassA será acionado em DoSomething. ClassB não precisa acessar ClassA para acionar código controlado por ClassA.

                                                --------|       |--------

- Quando a ClassA não precisar mais lidar com eventos da ClassB, ela poderá cancelar a assinatura da ClassB, o que precisa de uma referência.

 ---- B.ev_trigger -= A.OnEventTrigger;

- Mas e se A não for mais referenciado? Você poderia armazenar o manipulador de eventos da classe A e usá-lo para cancelar a assinatura

 ---- Action eventHandlerA = A.OnEventTrigger;
 ---- B.ev_trigger += eventHandlerA;

 ---- //Arbitrary code here
 ---- B.ev_trigger -= eventHandlerA;


- se você for descartar um objeto, deverá cancelar a assinatura de seus manipuladores de eventos. Este é um motivo comum para tornar um objeto IDisposable e substituir o método Dispose
- Caso contrário, essa referência de objeto permanecerá na memória e acho que se você tentar referenciá-la, uma exceção será lançada. ObjectDisposedException ou algo assim


*/
#endregion
#region Lists
/*

Para armazenar e buscar os elementos, é usado o [ List<T> ], que se encontra no namespace [ System.Collections.Generic ]. 
List<T> também pode armazenar elementos duplicados.

------------------------------------------------------------------------------------------------------------------------

//cria uma lista de [ string ] 

var countries = new List<string>();  
countries.Add("India");  
countries.Add("Australia");  
countries.Add("Japan");  
countries.Add("Canada");  
countries.Add("Mexico");  
 
//itera a lista com um loop [ foreach ]
foreach (var country in countries)  
{  
    Console.WriteLine(country); //faz código
}  

________________________________________
Output:
India
Austraia
Japan
Canada
Mexico

------------------------------------------------------------------------------------------------------------------------

*/
#endregion
#region Importants!

#region Update Hooks
/*

Qualquer coisa com [ Trigger ] no nome, será reproduzido a cada frame
ou seja, nem loop precisa :3

 */
#endregion

#endregion
#region Modding

#region Game Input 
/*

Rain World usa esse tipo de coisa pra poder pegar os inputs do ``Player``

[ .jmp ]            - quando aperta pra pular
[ .thrw ]           - quando aperta pra jogar
[ .pckp ]           - quando aperta pra pegar

if (_player.input[0].jmp && _player.input[0].pckp)
{

  //faz algo

}

_player.input[0] aparenta ser um array de ``Int``, mas ainda não sei pq

 */
#endregion
#region hooks and parameters 

#region orig and parameters

//o compilador na verdade não omite argumentos opcionais, o que acontece é quando você tem um método com um argumento opcional como este

// ---- public void DoThing(int x = 10) { }

//e você chama assim

// ---- item.DoThing();

//o valor padrão apenas é inserido:

// ---- item.DoThing(10);

//coisas semelhantes acontecem com argumentos de parâmetros
//para o codificador, parece que você está passando um número variável de argumentos, mas o compilador na verdade os empacota em um array, e apenas esse array é passado como argumento

#endregion
#region hook tip
/*

argumentos que são passados ​​para o seu gancho
você não precisa procurá-los em algum lugar fora

o objetivo disso é deixar claro o que qualquer método PRECISA para funcionar corretamente apenas olhando sua definição, sem ler seu código real, 
para que você saiba se forneceu os argumentos corretos ANTES de compilar o código e executá-lo.
algumas outras linguagens, como Lua ou Javascript, permitem passar qualquer número de argumentos em qualquer sequência

todos os métodos em c# são rigorosos quanto aos argumentos que recebem e em que ordem.
Existem alguns truques de linguagem que fazem parecer que você pode omitir argumentos ou usar um número variável de argumentos, mas esses são apenas truques

se o seu gancho receber argumentos On.SomeClass.orig_SomeMethod orig, SomeClass self, int x, int y, string id, seu orig deve ser chamado como orig(self, x, y, id). 
ele deve sempre receber exatamente a mesma sequência de argumentos - self, um inteiro, outro inteiro e uma string

você pode alterar os valores desses argumentos (como passar números diferentes em vez de x e y), mas todo o conjunto de argumentos deve permanecer o mesmo

 */
#endregion

#endregion
#region KeyCodes!
/*

também uma observação importante: o método GetKey retorna verdadeiro durante qualquer quadro em que a tecla é pressionada. 
este irá funcionar corretamente, mas GetKeyDown e GetKeyUp que são usados ​​para verificar se a tecla começou ou parou de ser pressionada este quadro não irá

                                                            -------- MICROSOFT --------

Microsoft tem um Debug.WriteLine, e suas funcionalidades de input próprias

ahh, e se você usar o sistema de entrada da Microsoft, ele não detectará os atalhos de teclado do jogo. (IRRELEVANTE!)

                                                            --------   UNITY   --------

Unity tem um Debug.Log
e KeyCode é uma enum da Unity
é bem provável que funcione, pois o jogo foi feito na Unity.

                                                            --------  REWIRED  --------

RWInput fPARA keyhandling.
Rain World usa Rewired para suporte á controles de console.
também provável que funcione. é uma funcionalidade pré definida

Verificar chaves apenas uma vez é opcional. Sinta-se à vontade para ficar sem ele. Se você observar como as ferramentas de desenvolvimento lidam com entradas, verá que há booleanos perdidos 
chamados oDown, hDown. Não são ótimos nomes de variáveis, mas funcionam para ferramentas de desenvolvimento

Sim, você precisa incluir LogLevel como parte do nome do método ou fornecê-lo como argumento para o log.

 */
#endregion
#region         .
/*

 Os [ . ] são pegos da ESQUERDA pela DIREITA. então:

 ---- self.bool_something.bool_something.bool_something

 é basicamente isso


 ah, e tambem tem pra método

 ---- self.thing().thing().thing()

 */
#endregion
#region Non-Statics and Statics info

//um gancho sendo estático ou não é quase sem sentido. PO fato de você poder ter ganchos não estáticos não o ajudará.
//Comparar o gancho com qualquer coisa não tem sentido. Isso não vai te ajudar.

#endregion

#endregion
#region Vector2
/* Dica de Fluffball sobre Vector 2

Se não for um sprite, provavelmente usa um Vector2 para todas as suas coordenadas. Tenha isso em mente.

Futile -> Tem x,y separados, mas você pode obter a posição retornada como Vector2.
Praticamente todo o resto -> UnityEngine.Vector2

Eu costumo adicionar

using Vector2 = UnityEngine.Vector2; no topo de qualquer classe que precise de um. Não tente usar a versão da Microsoft.
Ah, também existe o WorldCoorden que é usado às vezes.

 */
#endregion
#region Logs
/*
Além disso, você deve saber e fazer anotações para não esquecer.

 ---- Como registrar coisas no RainWorld. Não pode usar Console.WriteLine!
 
 ---- Saída de registro

 ---- log.Log registra apenas em mods.log/LogOutput
 
 ---- Debug.Log registra apenas em console.log

 ---- Limitações do método de log

 ---- Nem todos os métodos de log são iguais.

 ---- log.Log é mais confiável. Ele fará login em locais que o Debug.Log não pode.
 
 ---- Debug.Log envia para o console de registro acessível no jogo pressionando H e depois K com o mod devtools ativo.

Você pode registrar chaves em tempo real no console se configurá-lo da maneira correta.

                                                                                        --------|        |--------

e Os métodos de log não aceitam apenas strings, mas você pode colocar qualquer objeto em uma dessas instruções e ele registrará o ToString() para esse objeto, 
ou o tipo de dados do objeto se ele não tiver um ToString(), ou seu Svalue se for um tipo de valor.
    
                                                                                        --------|        |--------

Você obtém muitos resultados de depuração do jogo em console.log se já olhou esse log depois de iniciar uma campanha normal com devtools ativos. Pode ser spam dependendo do que você está fazendo
Sim, você pode usar ambos.

                                                                                        --------|        |--------

Você vai me odiar por dizer isso, mas cada um tem seus altos e baixos e você deve escolher o que funciona melhor na situação ou de acordo com suas preferências.

 [ log.Log ]    ----   Você obtém arquivos de log mais legíveis, mas não obtém a saída exibida no mesmo console.

 [ Debug.Log ]     ----   possui o console do jogo, mas seus logs não são formatados.

                                                                                        --------|        |---------

                                                                                        [       log.Log        ]

----        Cria uma mensagem com o nome do seu mod + nível de log à esquerda no BepInEx pllugins porra

                                                                                        [       Debug.Log         ]

----        Despeja tudo o que você pedir para registrar no console.log e exibe no console do jogo. Não informa a qual mod ele pertence.


Você pode usar uma mensagem como Key input triggered: " + Input.inputString <- Não sei como você obtém um Unity KeyCode de seu LegacyInputModule. (e eu entendi nada ainda LMAO)
*/

#region =>

//basicamente, quando você vê => dentro do corpo de um método, isso significa que algo está criando funções locais (elas também são chamadas de encerramentos ou funções lambda)

#endregion
#endregion
#region C# and Python recoils
/*


espaços e quebras de linha literalmente não importam para o compilador                                                                                                  C#
você pode escrever seu programa inteiro em uma única linha gigante                                                                                                      C#

em c#, o recuo não importa                                                                                                                                              C#
seu código pode ter o estilo que você quiser e ainda funcionará, desde que você tenha escrito algo que realmente faça sentido                                           C#
você pode realmente fazer isso na maioria das linguagens modernas                                                                                                       C#
linguagens como Python, onde o recuo é significativo, são uma minoria                                                                                                   C#

em python, se você recuar ou desindentar uma parte do seu código, isso geralmente muda o que o programa realmente faz                                                   PY

se você tiver sorte, produzirá um erro em breve; se não tiver sorte, não produzirá um erro e você terá que procurar manualmente o que está quebrado                     PY


 */
#endregion
#region keyloggers
/*
//Sugira usar static e possivelmente colocar em uma classe distinta que você possa acessar quando precisar, ou arrastar para outros mods.
public static void LogInput(KeyCode keyPressed)
{
//Log message formatting here

LogMessage(msg);
}

public static void LogMessage(string msg)
{
//All of your log logic hwre, so you can stop copy/pasting them
}
 */


#endregion
#region types convert
/*

Outra coisa sobre a conversão de tipos. Você não pode simplesmente converter um objeto para qualquer tipo. Apenas algumas conversões são suportadas.

Observe a hierarquia de tipos de uma classe se não tiver certeza sobre o que é uma conversão de tipo válida.

- AbstractCreature herda de AbstractPhysicalObject
- AbstractPhysicalObject herda de AbstractWorldEntity

Isso significa que um AbstractCreature pode ser armazenado como um AbstractPhysicalObject ou um AbstractWorldEntity, mas o oposto não pode ser dito.

Isso é ilegal

AbstractPhysicalObject myObj = new AbstractPhysicalObject();

AbstractCreature creature = (AbstractCreature)myObj;


                                                                                --------|        |--------

Agora você pode verificar o tipo de um objeto com uma conversão de tipo nullsafe.

//Não sabemos se este é um AbstractCreature
AbstractPhysicalObject someObj;

//Verifica se someObj é um AbstractCreature com um tipo nullsafe convertido

AbstractCreature someCreature = someObj as AbstractCreature;

//someCreature será nulo se someObj não puder ser convertido em AbstractCreature
if (someCreature != null)
{
//Sabemos que someObj é uma AbstractCreature
}
 */
#endregion
#region virtual
/*

Virtual também não é importante aqui. Não precisa ser. Use virtual se você acha que deseja herdar da classe que você cria com diferentes efeitos ou configurações infantis.

Quando uma classe herda de outra classe, ela também herda toda a sua lógica base.
                                                            
                                                                        |--------|

---- Um método marcado como virtual permite que qualquer classe herdada substitua opcionalmente a lógica na classe base criando um método idêntico usando a palavra-chave override.

---- Um método que não possui uma palavra-chave virtual só pode ser ocultado por uma classe herdada, e isso é feito com a palavra-chave new.

---- Ocultar um método de classe base não é tão útil quanto sobrescrevê-lo. As classes projetadas para serem herdadas devem usar métodos virtuais que podem precisar ser substituídos por uma classe herdada.
                                                                          
                                                                        |--------|


                                                                     ||||--------||||

public class MyBaseClass
{
    //A palavra-chave virtual permite que uma classe herdada substitua esta lógica por uma nova implementação
    public virtual void Method1()
    {
      //Some logic here
    }
    
    //Este método não é virtual e só pode ser ocultado por uma classe herdada.
    public void Method2()
    {

    }
}

public class MyNewClass : MyBaseClass
{
    //A palavra-chave override permite que MyNewClass substitua a lógica original por outra coisa
    public override void Method1()
    {
        //A lógica base ainda pode ser chamada usando a palavra-chave base semelhante a chamar orig
        base.Method1();
    }
    
    //PO método2 só pode ser ocultado por esta classe, pois não está marcado como virtual.
    //Em alguns casos, a lógica base pode ser executada em vez desta lógica. É uma prática de codificação melhor substituir em vez de ocultar métodos.
    public new void Method2()
    {

    }
}

                                                                     ||||--------||||

---- Às vezes não é possível substituir métodos porque a classe original não foi projetada para ser herdada.

---- Isso será true para a maioria das classes RainWorld, mas também para certas bibliotecas do .NET framework.

List, por exemplo, não marca seus métodos como virtuais. Para criar uma versão customizada de um método List nativo, a palavra-chave new deve ser usada para customizar a função.


 */
#endregion
#region abstract
/*
                                                                                            [ abstract ]

- Isso faz com que você não possa construir esta classe diretamente.
- Para construir esta classe, você precisa construir uma classe que herde da classe.

                                                                                            [  sealed  ] 

- Este é o conceito oposto ao abstrato. Você marca uma classe como selada para evitar que ela seja herdada.
- Na minha opinião, não acho que você deva usar selado.

------------------------------------------------------------------------------------------------------------------------------------------------------------

Se você empregar disciplina de codificação adequada, não precisará de palavras-chave [ abstract ]/[ sealed ]. Eles são mais úteis para APIs/bibliotecas públicas.
Usarei abstract quando quiser deixar claro que não há um motivo útil para criar uma instância genérica da classe base.

 */
#endregion
#region constructor and overloads
/*

Qualquer coisa que você precisar de fora da sua classe personalizada deve ser passada para o construtor.
Os construtores podem ser vistos como um tipo especial de método. Eles terminam em (), assim como os métodos.

Em C#, podemos usar [ this ] para nos referir a um construtor sobrecarregado na classe atual. Também podemos usar [ base ] para nos referir a um construtor em uma classe base (herdada).

Isso também funciona com métodos.

- Refere-se a um método chamado SomeMethod na classe atual.

this.SomeMethod();


- Refere-se a um método chamado SomeMethod na classe atual ou na classe base.

base.SomeMethod();



Isso funcionaria da mesma forma para campos e propriedades também.

                                                    ||||-----------------------||||

Isso é chamado de sobrecarga e você pode sobrecarregar construtores e métodos.
Você pode passar o mouse sobre os métodos e às vezes verá na dica + 2 sobrecargas

Isso significa que existem dois métodos com esse nome, mas com argumentos diferentes.

Ao completar o nome do método, uma nova dica de ferramenta aparece com setas.
Imagem --<
Você pode clicar nessas setas para percorrer as diferentes sobrecargas de método que pode usar.
List.IndexOf possui uma variante que leva três argumentos.

                                                    ||||-----------------------||||

 ---- Mesmo método, argumentos diferentes.
 ---- Não é incomum que um método sobrecarregado chame outro método sobrecarregado.
 ---- [ this ] versus [ base ] permite ao compilador saber se deve verificar este método na classe atual ou em uma classe herdada.

Este método substitui um método chamado Activate na classe herdada.

Classes diferentes, mesmo método, mesmos argumentos.

[ base ] permite que o compilador saiba que deve chamar a versão na classe base, não na classe atual.

Isso é muito semelhante ao modo como orig funciona para ganchos.

Chame [ base ] se quiser executar o código base original.
Deixe-o de fora e o código base nunca será executado.

Observe o [ : ]

public CustomExplosion(Creature creature, Vector2 Pos) : this(creature.room, creature, Pos, null) <------------------------------->
{
    //faz código
}

É exatamente assim que você herda classes, mas aqui ela é reutilizada para sobrecarga do construtor.

Neste exemplo, eu defino três malditas sobrecargas.

 ---- É considerada uma boa prática de programação enviar seus argumentos para a sobrecarga com o maior número de argumentos e preencher os valores ignorados com valores padrão.


Você verá que os dois primeiros construtores enviam seus argumentos para o terceiro construtor, e esse construtor envia seus argumentos para o construtor base.

 ---- Enviar argumentos para um construtor base, se houver algum definido, não é opcional. Você será forçado a fazer isso.

Se você precisar de mais argumentos ou argumentos diferentes, você só precisa criar uma nova sobrecarga. Tenha quantas sobrecargas desejar.

                                                    ||||-----------------------||||

Não precisamos mais especificar o room diretamente, pois passamos um objeto para o construtor contendo uma referência ao room.
Ainda devemos passar a referência room para a base, porque estamos lidando com construtores no jogo que esperam um argumento Room.

Ao ter uma classe personalizada, podemos reduzir consideravelmente a quantidade de informações necessárias para criar um objeto.
Lembre-se de que antes você precisava fornecer todas essas informações para criar um objeto Explosão.
Apenas lembre-se de que qualquer coisa que faça parte do construtor só precisa estar em uma das sobrecargas do construtor
 ---- Não tente ter a mesma lógica em todos os construtores sobrecarregados.

Somente este chama InitializeChildren, o resto dos construtores não é necessário.


                                                    ||||-----------------------||||

Você pode atribuir valores padrão aos argumentos dos métodos/construtores como este.
Imagem ---<
Se killTagHolder não for necessário, você não precisa colocar null como argumento. PO compilador pode colocar null lá para você.

Todos os parâmetros opcionais devem ser definidos após todos os parâmetros obrigatórios.


                                                    ||||-----------------------||||


Você pode definir qualquer campo de classe, até mesmo campos base entre colchetes depois de invocar seu construtor dessa forma.

Limitações disso:
 ---- A lógica base será aplicada antes que o valor entre chaves seja atribuído. Às vezes isso será importante, especialmente com a lógica do RainWorld. Tome cuidado.
 ---- Isto é funcionalmente o mesmo que atribuir dentro do próprio construtor

public CustomExplosion(Creature creature): this(creature, creature.bodyChunks[0].Pos, null)
{
  //Isso não será alterado até que a lógica base seja executada primeiro
  LifetIme = 5;
}

PO valor pode ser adicionado desde que o campo não seja privado, protegido ou somente leitura. Se for somente leitura, deverá ser definido no construtor.


                                                    ||||-----------------------||||


Minha sugestão acima é muito útil, pois permite personalizar campos sem precisar passar argumentos para um construtor.

Você deve ter em mente que às vezes a lógica é executada dentro do construtor que pode usar esse valor.
Se for definido tarde demais, essa lógica não se aplicará ao seu valor.

Felizmente para você, a maioria dos argumentos para Explosion não possui nenhuma lógica que os afete no construtor.
Você pode alterar esses valores dentro do seu construtor ou usando esses colchetes.

Isso é tudo que você precisa saber sobre construtores e sobrecarga. Você parece ter escrito um pequeno romance de notas que é maravilhoso!

 */
#endregion
#region idk 3
/*

Meu construtor foi baseado especificamente em explosões, e eu estava pensando em fazer a aula para vocês, para ajudar.
Mas você precisa de experiência na criação de classes para essas coisas.

Sugiro que você dê um nome mais relacionado a explosões, só para que eu não precise perder tempo explicando por que você ficou confuso mais tarde.
Mas depende de você (pelo jeito, to lascado)

PO poder pode referir-se a vários campos. Você pode querer adicionar um resumo que diga o que ele faz.
É perfeitamente normal ter um argumento que altera vários campos ao mesmo tempo!!!

Você poderia codificar o que significa poder em seu construtor. Isso pode alterar vários campos para você.
Se você quiser... é com você. As aulas expandem seu controle. Isso não é algo para se temer. Segure esse controle, dobre-o à sua vontade

 */
#endregion
#region idk4
/*

Enquanto estamos nas instruções switch:
Você deve definir um padrão ao criar um enum como este, ou o primeiro valor definido em seu enum será o padrão automaticamente
Se você não tiver um, o compilador fará com que Lower seja o padrão porque ele é definido primeiro.

Você pode atribuir valores numéricos específicos às suas enumerações. PO enum definido com 0 sempre será o padrão.

 */
#endregion
#region ///
/*

ao ter um comentário com ///, tu pode colocar o mouse encima do alvo e trocar a descrição.
Isso ajuda na legibilidade.
mas tambéem achei inúil.

When you have a comment with ///, you can place the mouse over the target and change the description.
This helps with readability.
but I also found it useless.

------------------------------------------------------------------------------------------

/// <summary>
/// A sua descrição irá aparecer.   // your description will show
/// </summary>
/// <param name="orig"> Esta descrição descreve o [ orig ] // This description describes the [orig] </param>

------------------------------------------------------------------------------------------

*/
#endregion
#region cwt
/*

..shit

________________________________________________________________________________________________________________________________________

public static class cwt_slugg
{
    public class bool_something
    {

        //insert data here. i guess
        public bool bool_something;

        public bool_something()
        {
            this.bool_something = true;
        }
    }

    public static readonly ConditionalWeakTable<Player, bool_something> CWT = new();
    public static bool_something get_cwt(this Player self) => CWT.GetValue(self, _ => new());

    public static void PLS(Player self)
    {
        self.get_cwt();
    }
}

_________________________________________________________________________________________________________________________________________
*/
#endregion
#region self.Input[0.input
/*

Input[0] é a entrada atual do _player, Input[1] é a entrada do _player de 1 quadro atrás. 
Portanto, verificar se self.Input[0].jmp && !self.Input[1].jmp testa se o _player acabou de pressionar pular este quadro

os Inputs que já existem são:

self.input[0].jmp;      //Jump
self.input[0].pckp;     //Pick Up
self.input[0].thrw;     //Throw
self.input[0].x;        //X coordinate (left - right)
self.input[0].y;        //Y coordinate (up - down)



*/
#endregion
#region OPerators
/*

>	Maior que
<	Menor que

*/
#endregion
#region Directorys Types
/*_

slugg, Helpers, entenda isso.

Existem dois tipos de caminhos:

 ---- caminhos relativos
 ---- caminhos absolutos (completos)

Um caminho relativo é o que você tem. Ele contém apenas uma parte do endereço do arquivo. É relativo a algum diretório.
PO que você precisa é de um caminho completo.

ResolveFilepath e ResolveDirectory usam um caminho relativo ou um nome de arquivo/pasta e retornam um caminho completo válido para você.
Se você não deseja usar isso, você deve fornecer um caminho completo por algum outro meio. Não é recomendado não usá-lo, pois o caminho completo pode ser diferente de usuário para usuário. 
É apenas uma daquelas coisas que é um padrão e todos os modders que desejam criar um mod da maneira correta precisam se acostumar a usá-lo.

Também é interessante que, tecnicamente, qualquer coisa colocada no diretório raiz do assembly não precisa de um caminho absoluto
mas StreamingAssets não é o diretório raiz, então você precisa de um caminho completo

*/
#endregion
#region path

//Carregando um guia de recursos

/* 1. Está em uma ou mais subpastas controladas pelo meu mod?

- Criando o caminho

string myPath;

- Sim:
myPath = image_path.Combine("dirName1", "dirName2", "fileName");
dirName não pode incluir o nome da pasta do seu mod.


- Não:
myPath = "file_check name";

Em ambos os casos, não inclua a extensão do arquivo ao usar o Futile.

"fileName" ou "sprites/fileName"

Quando não estiver usando o Futile, você deve usar [ AssetManager.ResolveFilePath(myPath); ] e você deve incluir uma extensão de arquivo.

Inclui:

 -- Usando verificações File.Exists
 -- Mover, excluir, copiar arquivos

*/
/* 2. Carregando um recurso

 -- Use o Futile.atlasManager estático
 -- Futile.atlasManager.LoadImage(meuPath); //Para imagens
 -- Futile.atlasManager.LoadAtlas(meuPath); //Para atlas

Um deles deve ser chamado para cada recurso antes que um recurso possa ser usado.

 -- Armazenar o retorno destes métodos é opcional.

*/
/* 3. Buscando um recurso

Os recursos de imagem são armazenados em [ atlasManager._allElementsByName ] e recuperados através de [ Futile.atlasManager.GetElementWithName(myPath); ]
Futile lançará uma exceção se não conseguir encontrar o elemento aqui. Você pode torná-lo mais seguro verificando DoesContainElementWithName(myPath) primeiro.

 -- GetElementWithName retorna um FAtlasElement para seu recurso.

*/
/* 4. Criando seu sprite ou outro drawable

Adicione o FAtlasElement como parâmetro a um construtor que usa um. (FSprite, FLabel, etc) do seu recurso como parâmetro do construtor.

 -- Não tente convertê-lo em um FNode.


Exemplo
new FSprite(Futile.atlasManager.GetElementWithName(myPath)); ]

- PO elemento também pode ser definido através da propriedade element de um drawable existente.

existingFSprite.element = Futile.atlasManager.GetElementWithName(myPath); ]

Existem também texturas que você pode criar e definir. Não sei muito sobre como lidar com isso.

CONSELHO:

 -- Use a mesma fonte de caminho em todos os locais em que for usado. Recriar a origem do caminho aumenta a chance de erros.
 -- Não incluir a extensão do arquivo é bom, você precisa usar LoadImage ou LoadAtlas para adicionar o elemento à lista de nomes de elementos que o jogo pode reconhecer e acessar
 ^-- isso inclui em LoadImage

*/

#endregion
#region Being confused.

//mmmm

/* Modifying, Replacing or Creating?????????

Se você não estiver modificando um FSprite que já existe, não poderá criar um sem fornecer uma referência ao seu elemento.
alimentando-o diretamente com um FAtlasElement ou fornecendo-lhe a localização do recurso, e ele encontrará o FAtlasElement para você.

If you aren't modifying an FSprite that already exists, you cannot createone without providing a reference to your element either by directly feeding it an FAtlasElement. 
or by giving it the resource location, and it finds the FAtlasElement for you.

Tecnicamente você não precisa chamar GetElementWithName, você pode apenas deixar o construtor cuidar disso
mas se você não estiver criando um novo FSprite, você pode simplesmente modificar o campo do elemento

Technically you don't need to call GetElementWithName, you can just let the constructor handle it
but if you aren't creating a new FSprite, you can just modify the element field instead

*/
/*

//PUT ME IN AddChild, I'm begging you. 
FSprite mySprite = new FSprite(PUT SOMETHING HERE);

*/

#endregion
#region <> <> Generics <> <> <> <> <> <> <>
/*

portanto, genéricos são uma forma de escrever código que pode funcionar com diferentes tipos de dados e ainda ter comportamento semelhante. você pode escrever uma classe ou um método que funcione com dados sem saber exatamente com o que eles estão lidando.

você já sabe que em genéricos C# usam colchetes angulares <>. funciona assim:

1) tipo ou método especifica seus parâmetros genéricos:

____________________________________

class GenericClass<T> {  
  public T item;
}

//...

public U GenericMetod<U>(U item) {
  return item;
}

____________________________________

parâmetros genéricos são tipos, não valores. Se uma classe ou método possui parâmetros genéricos, dentro deles esse parâmetro genérico pode ser usado como um tipo normal. no exemplo acima,
GenericClass possui parâmetro genérico T, o que significa que dentro dessa classe você pode usar T como tipo para campos, variáveis ​​locais, retornos de métodos, etc, veja o item de campo. 
a mesma história com GenericMethod, que possui parâmetro genérico U.

ambos os exemplos têm um parâmetro genérico, mas uma classe/método genérico pode ter quantos você quiser

2) essas classes e métodos genéricos não estão prontos para serem usados, são como protótipos para criar mais classes e métodos. cada parâmetro genérico é um espaço em branco que você precisa preencher. 
você não pode dizer var thing = new GenericClass<T>(), mas pode dizer var thing = new GenericClass<int>().

apenas identificadores de tipo (string, int, SlugcatStats.Name) ficam entre colchetes angulares.
por exemplo, List é uma classe genérica. List<T> é um protótipo para qualquer lista - List<int>, List<string>, List<SlugcatStats.Name>. List<T> e List<int> são tipos diferentes (mas relacionados)

_____________________________

public class Generic<T, E>
{

    public static T Base;
    public static E Average;

}

_____________________________

além disso, classes/métodos genéricos podem adicionar requisitos (restrições) aos seus parâmetros genéricos, para garantir que você não tente armazenar um cavalo em um porta-copos.
funciona assim:

_______________________________________________________________________________________________________________

interface ICanBeDescribed {
  public string GetDescription();
}

public void GenericMethod<T>(T item) where T : ICanBeDescribed //this is a constraint, you can put parent interface or class requirements here
{
  Console.WriteLine(item.GetDescription());
}

_______________________________________________________________________________________________________________

aqui o método é genérico, mas graças ao parâmetro genérico, [ where T ] só pode ser preenchido com um tipo que implemente ICanBeDescribed. 
Além disso, o compilador sabe que qualquer T aqui sempre seria um ICanBeDescribed, então você pode usar métodos de [ ICanBeDescribed ] nele dentro do método

você pode restringir genéricos por classe pai, por interfaces, e também existem várias restrições especiais como class, struct ou notnull

meu progrresso:

_________________________

public class Something<bool_something>
{

    public static bool_something bool_something;

}

public static void Main()
{

    //bool_something();
    Something<float>.bool_something = 454f;
    Console.WriteLine(Something<float>.bool_something);

}

______________________

*/
#endregion
#region about Delegates more
/*

- Delegate      - Pode armazenar praticamente qualquer método
- Action<T>     - Armazena qualquer método que não retorne nada que tenha um parâmetro do tipo T
- Func<T1, T2>  - Armazena qualquer método que retorne um membro do tipo T2 e possua um parâmetro do tipo T1.
- Func<T>       – Apenas um argumento de tipo refere-se ao tipo de retorno. PO tipo de retorno sempre será o argumento do tipo mais à direita

Eles podem ser estendidos para incluir quantos parâmetros você precisar

Delegate myDel;

Ah, e tudo isso é anulável. Certifique-se de armazenar algo neles ou verifique se há nulo antes de tentar chamar.
Você também pode usar um operador condicional nulo:

myDel?.Invoke(); //Isso pode ser nulo, então verifique com [ ? ]

Se tiver certeza de que não será nulo, você pode chamar como um método normal.

myDel();

Para maior clareza, [ myDel ] é uma variável do tipo Delegate. Não confunda definir um tipo Delegate com estabelecer uma variável.

_______________________________________________________________________________________________________________________________________________

- Delegate      - Can store any method pretty much
- Action<T>     - Stores any method that returns nothing that has a parameter of type T
- Func<T1, T2>  - Stores any method that returns a member of type T2, and has a parameter of type T1.
- Func<T>       - Only one type argument refers to the return type. The return type will always be the right-most type argument

These can be extended to include as many parameters as you need

Delegate myDel;

Oh and these are all nullable. Make sure that you store bool_something in them, or check for null before trying to call.
You can also use a null-conditional operator:

myDel?.Invoke(); //This may be null, so check with [ ? ]

If you are certain that it wont be null, you can call like a normal method.

myDel();

For clarity, [ myDel ] is a variable of a Delegate type. Do not confuse defining a Delegate type with establishing a variable. 

*/
#endregion
#region Extension methods
/*

Como usar métodos de extensão

- Crie uma classe estática (qualquer classe estática)
- Crie um método estático nessa classe
- Inclua um parâmetro para esse método que comece com this com o tipo de classe à qual você deseja adicionar uma extensão.

How to use extension methods

- Create a static class (any static class)
- Create a static method in that class
- Include a parameter for that method that starts with this with the type of the class you want to add an extension to.

____________________________________________

public static class SomeClass
{
|
|   public static void MyExtension(this Player self)
|   {
|   |    
|   |   var self_room = self.room;
|   |   
|   }
|
}

____________________________________________


*/
#endregion
#region advices

#region look for the code fool
/*

just look at it and think about how the code should work
You're referencing by index, so you don't need to assign with a loop

*/
#endregion
#region File.ReadAllLines
/*

/*

File.ReadAllLines --> reads the entire file.
File.ReadAllLines(filepath);

*/

#endregion
#region 'AssetManager.ResolveFilePath'
/*  

- 'AssetManager.ResolveFilePath' is your friend
    - it can lead your directory for the mod folder

AssetManger.ResolveFilePath(filepath);

*/
#endregion
#region string
/*

You can never change a string's Svalue directly by invoking one of its helper method. 
The changed result is also returned as a Svalue you must store

*/
#endregion
#region string.Trim()
/*

Trim doesn't change the original string, it returns a modified string that is trimmed

*/
#endregion

#endregion
#region disable/enable feature
/*

-- Rawra
Yes this is works everywhere where you have a boolean value to work with, in C# you'd just use x = !x of course, rather than not.
________________________________
x = !x; // needs be booleans
________________________________

-- Moth 2 (not Vyn's alt)
Normally visibility isn't done with a bool but with a float that determines the opacity of the UI, in order to allow a smooth transition.

*/
#endregion

#endregion

#endregion

/*

apenas um aviso sobre arrastar arquivos para uma pasta em vez de copiar/colar.
A operação de arrastar pode excluir o arquivo que está lá antes de saber se a operação de movimentação falhará e, se a movimentação falhar, seu arquivo na origem e no destino será poof.

Isso não acontece em uma operação de cópia, pois o arquivo original não está sendo tocado.

just a warning about dragging files into a folder versus copy/paste.

----

The drag operation could delete the file_check that is there before it knows if the move operation will fail, and if the move fails, your file_check at both the source and destination goes poof.
This doesn't happen in a copy operation as the original file_check is not being touched. 

 */