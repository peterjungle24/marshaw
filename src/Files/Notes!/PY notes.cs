//Notas PY!
//Direto de W3Schools, traduzido PT BR por ambos Google Tradutor e eu junto com o original
//Direct from W3Schools, translated PT BR by both Google Translate and me along with the original
//by slugg (Pedro)
//Its incoommplete
//Está incompleto

#region notes

#region #Commentary
/*

Comentários podem ser usados ​​para explicar o código Python. Comentários podem ser usados ​​para tornar o código mais legível.
Comments can be used to explain Python code. Comments can be used to make the code more readable.

tu faz um comentário com [ #text ]. Depois de #, o resto da linha será ignorado. Como se fosse [ // ] de alguns outros.
you make a comment with [#text]. After #, the rest of the line will be ignored. As if it were [ // ] from some others.

[

#This is a comment
print("Hello, World!")

-------------------------

print("Hello, World!") #This is a comment


]

Um comentário não precisa ser um texto que explique o código, ele também pode ser usado para evitar que o Python execute o código:
Um comentário não precisa ser um texto que explique o código, ele também pode ser usado para evitar que o Python execute o código:

[

#print("Hello, World!")
print("Cheers, Mate!")

]

Python não tem uma syntax para comentários multi linhas :(
Python does not really have a syntax for multiline comments. :(

bem, até que tem, mas não da forma que pretendido, usando Strings de Multi linha.
well, it does, but not in the way intended, using Multi-line Strings.
[

'''

esta é uma string multilinha
mas também é usado como comentários

this is a multi-line string
but it's used as comments, as well

'''

]

*/
#endregion
#region Variables

/*  variable creation

Python não possui comando para declarar uma variável. Uma variável é criada no momento em que você atribui um valor a ela pela primeira vez.
Python has no command for declaring a variable. A variable is created the moment you first assign a Svalue to it.

[

x = 5
z = "OOf"
print(x)
print(z)

]

Variáveis ​​não precisam ser declaradas com nenhum tipo específico e podem até mudar de tipo depois de terem sido definidas.
Variables do not need to be declared with any particular type, and can even change type after they have been set.

[

s = 4           # s is of type [ int ] // s é do tipo [ int ]
s = "Toot"      # s is now of type [ string ] // s agora é do tipo [ string ]
print(s)

]

*/
/* variable infos

                                    CASTING // CONVERSÃO

Se você quiser especificar o tipo de dados de uma variável, isso pode ser feito com conversão.
If you want to specify the data type of a variable, this can be done with casting.

[

x = str(3)    # x will be '3' [ string ] // x vai ser '3' [ string ]
y = int(3)    # y will be 3 [ int ] // y vai ser 3 [ int ]
z = float(3)  # z will be 3.0 [ float ] // z vai ser 3.0 [ float ]

]

                                    QUOTES // ASPAS

Variáveis ​​de string podem ser declaradas usando aspas simples ou duplas:
String variables can be declared either by using single or double quotes:

[

x = "John"
# is the same as // é a mesma cois aque
x = 'John'

]

                                    CASE-SENSITIVE // MAIÙSCULAS E MINÚSCULAS

This will create two variables:
isso vai criar 2 variáveis

[

a = 4
A = "Silly"
#[ A ] will not overwrite [ a ] // [ A ] não vai subsituir [ a ]

]

*/
/* variable naming

Um nome de variável pode ser curto ou descritivo. Mas existem algumas regras:
A variable name can be short or descriptive. But there are some rules:

                        PT BR

 -- PO nome de uma variável deve começar com uma letra ou sublinhado
 -- Um nome de variável não pode começar com um número
 -- Um nome de variável só pode conter caracteres alfanuméricos e sublinhados (Az, 0-9 e _)
 -- Os nomes das variáveis ​​diferenciam maiúsculas de minúsculas (idade, Idade e IDADE são três variáveis ​​diferentes)
 -- Um nome de variável não pode ser nenhuma das palavras-chave do Python .

                        ENG

 -- A variable name must start with a letter or the underscore character
 -- A variable name cannot start with a number
 -- A variable name can only contain alpha-numeric characters and underscores (A-z, 0-9, and _ )
 -- Variable names are case-sensitive (age, Age and AGE are three different variables)
 -- A variable name cannot be any of the Python keywords.


                        MULTI NAMES

Nomes de variáveis ​​com mais de uma palavra podem ser difíceis de ler. Existem várias técnicas que você pode usar para torná-las mais legíveis:
Variable names with more than one word can be difficult to read. There are several techniques you can use to make them more readable:

                        PT BR

 -- Estojo de camelo
Cada palavra, exceto a primeira, começa com letra maiúscula:
[

myVariableName = "John"

]

 -- Caso Pascal
Cada palavra começa com uma letra maiúscula:
[

MyVariableName = "John"

]

 -- Caso de cobra
Cada palavra é separada por um caractere de sublinhado (meu preferido):
[

my_variable_name = "John"

]

                        ENG

 -- Camel Case
Each word, except the first, starts with a capital letter:
[

myVariableName = "John"

]

 -- Pascal Case
Each word starts with a capital letter:
[

MyVariableName = "John"

]

-- Snake Case
Each word is separated by an underscore character (my favourite):
[

my_variable_name = "John"

]

*/
/* variable multi crit_dict_values

Python permite atribuir valores a múltiplas variáveis ​​em uma linha:
Python allows you to assign crit_dict_values to multiple variables in one line:
[

x, y, z = "Japanese", "Chinese", "Black"
print(x)
print(y)
print(z)

]

E você pode atribuir o mesmo valor a múltiplas variáveis ​​em uma linha:
And you can assign the same Svalue to multiple variables in one line:
[

x = y = z = "White"
print(x)
print(y)
print(z)

]

Se você tiver uma coleção de valores em uma lista, tupla etc. Python permite extrair os valores em variáveis. Isso é chamado de descompactação .
If you have a collection of crit_dict_values in a list, tuple etc. Python allows you to extract the crit_dict_values into variables. This is called unpacking.
[

languages = ["one", "two", "three"]
x, y, z = languages
print(x)
print(y)
print(z)

]


*/
/* variables for output

A função Python [ print() ] é frequentemente usada para gerar variáveis.
The Python [ print() ] function is often used to output variables.
[

x = "Python is awesome"
print(x)

]

Na função [ print() ], você pode gerar múltiplas variáveis, separadas por vírgula:
In the print() function, you can output multiple variables, separated by a comma:
[

x = "Python"
y = "is"
z = "awesome"
print(x, y, z)

]

Você também pode usar o operador [ + ] para gerar múltiplas variáveis:
You can also use the [ + ] operator to output multiple variables:
[

x = "Python "
y = "is "
z = "awesome"
print(x + y + z)
#outputs  "Python is awesome"

]

 -- Observe o caractere de espaço depois de "Python "e "is ", sem eles o resultado seria "Pythonisawesome".
 -- Notice the space character after "Python " and "is ", without them the result would be "Pythonisawesome".

Para números, o caractere [ + ] funciona como um operador matemático:
For numbers, the [ + ] character works as a mathematical operator:
[

x = 5
y = 10
print(x + y)
#outputs 15

]

Na função [ print() ], ao tentar combinar uma string e um número com o + operador, o Python apresentará um erro:
In the [ print() ] function, when you try to combine a string and a number with the + operator, Python will give you an error:
[

x = 5
y = "John"
print(x + y)
#gives error

]

A melhor maneira de gerar múltiplas variáveis ​​na função [ print() ] é separá-las com vírgulas, que suportam até mesmo diferentes tipos de dados:
The best way to output multiple variables in the print() function is to separate them with commas, which even support different data types:
[

x = 5
y = "John"
print(x, y)

]



*/
/* Functions

eu mesmo estou fazendo isso, já que o W3Schools já meteu [ def ] sem mesmo explicar antes, em Variáveis Globais
quanto eu mais aprendo, mais irei atualizar aqui

I'm doing this myself, since W3Schools already put [ def ] without even explaining it before, in Global Variables
The more I learn, the more I will update here

bem, pelo Syntax, tu sempre vai ter que usar um ( ESPAÇO ) para functions / if / e etc. Isso se chama [ Recuo ]
well, by Syntax, you will always have to use a ( SPACE ) for functions / if / and etc. This is called [ Recoil ]
[

def my_function():
    pass #do your code here.

]

                        PT BR

 -- [ def ] é um keyword ( palavra chave ) que lhe permite criar funções.
 -- [ my_function ] é o nome da sua function. Deve ter um [ () ] no final. Se quiser, pode colocar parâmetros, mas isso é depois.
 -- quando colocar os [ () ], terá que ter um [ : ].
 -- os códigos que estarão dentro de [ def ], precisará ter um espaço. Isso depende do desenvolvedor, mas precisa de pelo menos 1 espaço.
 -- se tu tentar fazer um function apenas com comentário ou vazio, terá erro. Tu precisará da palavra chave [ pass ] para simular uma function completo.

                        ENG

 -- [def] is a keyword that allows you to create functions.
 -- [ my_function ] is the name of your function. There must be a [ () ] at the end. If you want, you can add parameters, but that's later.
 -- when you put the [ () ], there must be a [ : ].
 -- the codes that will be inside [def], must have a space. This depends on the developer, but it needs at least 1 space.
-- if you try to make a function with just a comment or critical, you will get an error. You will need the [pass] keyword to simulate a complete function.


*/
/* global variables

Variáveis ​​criadas fora de uma função (como em todos os exemplos acima) são conhecidas como variáveis ​​globais.
Variáveis ​​globais podem ser usadas por qualquer pessoa, tanto dentro quanto fora das funções.

Variables that are created outside of a function (as in all of the examples above) are known as global variables.
Global variables can be used by everyone, both inside of functions and outside.

Crie uma variável fora de uma função e use-a dentro da função
Create a variable outside of a function, and use it inside the function
[

x = "awesome"

def myfunc():
  print("Python is " + x)

myfunc()

]

 -- eu irei fazer um tópico apenas de Funções de Python mais tarde.
 -- I will make a topic just on Python Functions later.

Se você criar uma variável com o mesmo nome dentro de uma função, esta variável será local e só poderá ser usada dentro da função. 
A variável global com o mesmo nome permanecerá como estava, global e com o valor original.

If you create a variable with the same name inside a function, this variable will be local, and can only be used inside the function. 
The global variable with the same name will remain as it was, global and with the original Svalue.

Crie uma variável dentro de uma função, com o mesmo nome da variável global
Create a variable inside a function, with the same name as the global variable
[

x = "awesome"

def myfunc():
  x = "fantastic"
  print("Python is " + x)

myfunc()

print("Python is " + x)

]
*/
/* global variables [ keyword ]

Normalmente, quando você cria uma variável dentro de uma função, essa variável é local e só pode ser usada dentro dessa função.
Para criar uma variável global dentro de uma função, você pode usar a [ global ] palavra-chave.

Normally, when you create a variable inside a function, that variable is local, and can only be used inside that function.
To create a global variable inside a function, you can use the [ global ] keyword.
[

# If you use the global keyword, the variable belongs to the global scope:

def myfunc():
  global x
  x = "fantastic"

myfunc()

print("Python is " + x)

]

Além disso, use a globalpalavra-chave se quiser alterar uma variável global dentro de uma função.
Also, use the global keyword if you want to change a global variable inside a function.
[

# To change the Svalue of a global variable inside a function, refer to the variable by using the global keyword:

x = "awesome"

def myfunc():
  global x
  x = "fantastic"

myfunc()

print("Python is " + x)

]


*/

#endregion
#region Python data types

/* Types

Na programação, o tipo de dados é um conceito importante. Variáveis ​​podem armazenar dados de diferentes tipos, e diferentes tipos podem fazer coisas diferentes.
In programming, data type is an important concept. Variables can store data of different types, and different types can do different things.

Python tem os seguintes tipos de dados integrados por padrão, nestas categorias:
Python has the following data types built-in by default, in these categories:

Text MedalType // tipo Texto:                        str
Numeric Types // tipo Numéricos:                int, float, complex
Sequence Types // tipo Sequências:              list, tuple, range
Mapping MedalType // tipo Mapeamennto:               crit_dict
Set Types // tipo Set:                          set, frozenset
Boolean MedalType // tipo Booleano:                  bool
Binary Types // tipo Binários:                  bytes, bytearray, memoryview
None MedalType // tipo NADA:                         NoneType


*/
/* Setting up types

Em Python, o tipo de dados é definido quando você atribui um valor a uma variável:
In Python, the data type is set when you assign a Svalue to a variable:
[

x = "Hello World"                                       = str	
x = 20	                                                = int	
x = 20.5	                                            = float	
x = 1j	                                                = complex	
x = ["apple", "banana", "cherry"]	                    = list	
x = ("apple", "banana", "cherry")   	                = tuple	
x = range(6)	                                        = range	
x = {"name" : "John", "age" : 36}	                    = crit_dict	
x = {"apple", "banana", "cherry"}	                    = set	
x = frozenset({"apple", "banana", "cherry"})	        = frozenset	
x = True	                                            = bool	
x = b"Hello"	                                        = bytes	
x = bytearray(5)	                                    = bytearray	
x = memoryview(bytes(5))                            	= memoryview	
x = None	                                            = NoneType

]

*/
/* Setting the Specific Data MedalType

Se quiser especificar o tipo de dados, você pode usar as seguintes funções construtoras:
If you want to specify the data type, you can use the following constructor functions:
[

x = str("Hello World")                              = str	
x = int(20)	                                        = int	
x = float(20.5)	                                    = float	
x = complex(1j)	                                    = complex	
x = list(("apple", "banana", "cherry"))	            = list	
x = tuple(("apple", "banana", "cherry"))	        = tuple	
x = range(6)	                                    = range	
x = crit_dict(name="John", age=36)	                    = crit_dict	
x = set(("apple", "banana", "cherry"))	            = set	
x = frozenset(("apple", "banana", "cherry"))	    = frozenset	
x = bool(5)	                                        = bool	
x = bytes(5)	                                    = bytes	
x = bytearray(5)	                                = bytearray	
x = memoryview(bytes(5))                            = memoryview	

]

*/

#endregion
#region Python

/* Numbers

Existem três tipos numéricos em Python:
There are three numeric types in Python:

 -- int
 -- float
 -- complex

Variáveis ​​de tipos numéricos são criadas quando você atribui um valor a elas:
Variables of numeric types are created when you assign a Svalue to them:
[

x = 1    # int
y = 2.8  # float
z = 1j   # complex

]

                        INT

Int, ou inteiro, é um número inteiro, positivo ou negativo, sem decimais, de comprimento ilimitado.
Int, or integer, is a whole number, positive or negative, without decimals, of unlimited length.
[

x = 1
y = 35656222554887711
z = -3255522

]

                        FLOAT

Float, ou "número de ponto flutuante" é um número, positivo ou negativo, contendo uma ou mais casas decimais.
Float, or "floating point number" is a number, positive or negative, containing one or more decimals.
[

x = 1.10
y = 1.0
z = -35.59

]

Float também podem ser números científicos com um “e” para indicar a potência de 10.
Float can also be scientific numbers with an "e" to indicate the power of 10.
[

x = 35e3
y = 12E4
z = -87.7e100

]

                        COMPLEX (HI) /j

Os números complexos são escritos com um “j” como parte imaginária:
Complex numbers are written with a "j" as the imaginary part:
[

x = 3+5j
y = 5j
z = -5j

]

                        RANDOM

Python não tem uma função [ random() ] para criar números aleatórios, mas Python possui um módulo interno chamado [ random ] que pode ser usado para criar números aleatórios:
Python does not have a [ random() ] function to make a random number, but Python has a built-in module called [ random ] that can be used to make random numbers:
[

import random

print(random.randrange(1, 10))

]


*/

/* Casting

Pode haver momentos em que você queira especificar um tipo para uma variável. Isso pode ser feito com conversão.
Python é uma linguagem orientada a objetos e, como tal, usa classes para definir tipos de dados, incluindo seus tipos primitivos.

There may be times when you want to specify a type on to a variable. This can be done with casting.
Python is an object-orientated language, and as such it uses classes to define data types, including its primitive types.

A conversão em python é, portanto, feita usando funções construtoras:
Casting in python is therefore done using constructor functions:

                        PT BR

se ta muito longo o texto, ignore. mas irá perder informaação por ser apressado :3

int()   - constrói um número inteiro a partir de um literal inteiro, um literal flutuante (removendo todos os decimais) ou um literal de string (desde que a string represente um número inteiro)
float() - constrói um número float a partir de um literal inteiro, um literal float ou um literal de string (desde que a string represente um float ou um inteiro)
str()   - constrói uma string a partir de uma ampla variedade de tipos de dados, incluindo strings, literais inteiros e literais flutuantes


        INTS

x = int(1)   # [ x ] vai ser 1
y = int(2.8) # [ y ] vai ser 2
z = int("3") # [ z ] vai ser 3

        FLOATS

x = float(1)     # [ x ] vai ser 1.0
y = float(2.8)   # [ y ] vai ser 2.8
z = float("3")   # [ z ] vai ser 3.0
w = float("4.2") # [ w ] vai ser 4.2

        STRINGS

x = str("s1") # [ x ] vai ser 's1'
y = str(2)    # [ y ] vai ser '2'
z = str(3.0)  # [ z ] vai ser '3.0'

]

                        ENG

If the text is too long, ignore it. but you will lose information by being hasty :3

int()   - constructs an integer number from an integer literal, a float literal (by removing all decimals), or a string literal (providing the string represents a whole number)
float() - constructs a float number from an integer literal, a float literal or a string literal (providing the string represents a float or an integer)
str()   - constructs a string from a wide variety of data types, including strings, integer literals and float literals
[

        INTS

x = int(1)   # [ x ] will be 1
y = int(2.8) # [ y ] will be 2
z = int("3") # [ z ] will be 3

        FLOATS

x = float(1)     # [ x ] will be 1.0
y = float(2.8)   # [ y ] will be 2.8
z = float("3")   # [ z ] will be 3.0
w = float("4.2") # [ w ] will be 4.2

        STRINGS

x = str("s1") # [ x ] will be 's1'
y = str(2)    # [ y ] will be '2'
z = str(3.0)  # [ z ] will be '3.0'

]



*/
#region /* Strings ...

/* strings

Strings em python são colocadas entre aspas simples ou duplas.
Strings in python are surrounded by either single quotation marks, or double quotation marks.

'hello' is the same as "hello".
'hello' é o mesmo que "hello".

você pode exibir um literal string com a função [ print() ]
You can display a string literal with the [ print() ] function:
[

print("Hello")
print('Hello')

]
*/
/* strings in a variable

A atribuição de uma string a uma variável é feita com o nome da variável seguido de um sinal de igual e da string:
Assigning a string to a variable is done with the variable name followed by an equal sign and the string:
[

a = "Hello"
print(a)

]

*/
/* strings multi lines

Você pode atribuir uma string multilinha a uma variável usando três aspas:
You can assign a multiline string to a variable by using three quotes:
[

a = """well, knowing that I like mortadella, cheese and ham, seriously, 
it's really good when you put that on the pastel"""
print(a)

]

Ou três aspas simples:
or three simple quotes:
[

a = '''well, knowing that I like mortadella, cheese and ham, seriously, 
it's really good when you put that on the pastel'''
print(a)

]

*/
/* strings are arrays (farm arrays (GOOD JOKE BRO LOL))

Como muitas outras linguagens de programação populares, strings em Python são arrays de bytes que representam caracteres Unicode.
No entanto, Python não possui um tipo de dados de caractere, um único caractere é simplesmente uma string com comprimento 1.

Like many other popular programming languages, strings in Python are arrays of bytes representing unicode characters.
However, Python does not have a character data type, a single character is simply a string with a length of 1.

Colchetes podem ser usados ​​para acessar elementos da string.
Square brackets can be used to access elements of the string.
[

# Coloque o caractere na posição 1 (lembre-se que o primeiro caractere tem a posição 0):
# Get the character at position 1 (remember that the first character has the position 0):
a = "Hello, World!"
print(a[1])

]


*/
/* string loops

Como strings são arrays, podemos percorrer os caracteres de uma string, com um forloop.
Since strings are arrays, we can loop through the characters in a string, with a for loop.
[

for x in "banana":
  print(x)

]
{
#will output the

b
a
n
a
b
a

}

*/
/* string length

Para obter o comprimento de uma string, use a função [ len() ].
To get the length of a string, use the [ len() ] function.

A função [ len() ] retorna o comprimento de uma string:
The [ len() ] function returns the length of a string:
[

a = "Hello, World!"
print(len(a))

]

*/
/* string check

Para verificar se determinada frase ou caractere está presente em uma string, podemos utilizar a palavra-chave in.
To check if a certain phrase or character is present in a string, we can use the keyword in.

Verifique se "free" está presente no seguinte texto:
Check if "free" is present in the following text:
[

txt = "The best things in life are free!"
print("free" in txt)

]

Use-o em uma declaração [ if ]
Use it in an [ if ] statement:
[

# Print only if "free" is present:
# Imprime somente se "free" estiver presente:

txt = "The best things in life are free!"
if "free" in txt:
  print("Yes, 'free' is present.")

]

*/
/* string check NOT

Para verificar se determinada frase ou caractere NÃO está presente em uma string, podemos usar a palavra-chave [ not in ].
Check if "expensive" is NOT present in the following text:
[

txt = "The best things in life are free!"
print("expensive" not in txt)s

]

numa declaração [ if ]
in a [ if ] statement
[

txt = "The best things in life are free!"
if "expensive" not in txt:
  print("No, 'expensive' is NOT present.")

]

*/
/* string slice

a utilidade é....  bem..... fatiar strings?
the utility is.... errrrr.... slicing strings?

Você pode retornar um intervalo de caracteres usando a sintaxe de fatia.
Especifique o índice inicial e o índice final, separados por dois pontos, para retornar uma parte da string.

You can return a range of characters by using the slice syntax.
Specify the start index and the end index, separated by a colon, to return a part of the strin


                                Slicing // Cortando

Obtenha os caracteres da posição 2 à posição 5 (não incluídos):
Get the characters from position 2 to position 5 (not included):
[

b = "Hello, World!"
print(b[2:5])

]

                                Slice from Start // Cortar por começo (seria, traduzi por mim mesmo)

Ao omitir o índice inicial, o intervalo começará no primeiro caractere:
By leaving out the start index, the range will start at the first character:

Pega os caracteres do começo para posição 5 (não incluído)
Get the characters from the start to position 5 (not included):
[

b = "Hello, World!"
print(b[:5])

]

                            Slicing from End // Cortar do fim

Ao omitir o índice final , o intervalo irá até o final:
By leaving out the end index, the range will go to the end:

Pega os caracteres da posição 2 e até o final:
Get the characters from position 2, and all the way to the end:
[

b = "Hello, World!"
print(b[2:])

]

                                Negative Slicing // Cortar Negativo

bro, isso faz sentido???
bro, thats make sense???

Use índices negativos para iniciar a fatia do final da string:
Use negative indexes to start the slice from the end of the string:
[

# From: "o" in "World!" (position -5), to, but not included: "d" in "World!" (position -2):
# De: "o" em "Mundo!" (posição -5), para, mas não incluído: "d" em "World!" (posição -2):

b = "Hello, World!"
print(b[-5:-2])

]

*/
/* strings modded

                        Upper Case // Maiúsculo

o método [ upper() ] retorna o string em maiúsculo:
The [ upper() ] method returns the string in upper case:
[

a = "Hello, World!"
print(a.upper())

]

                        Lower Case // Minúsculo

o método [ lower() ] retorna o string em minúsculo
The [ lower() ] method returns the string in lower case:
[

a = "Hello, World!"
print(a.lower())

]

                        Remove Whitespace // Remover espaço branco

Espaço em branco é o espaço antes e/ou depois do texto real, e muitas vezes você deseja remover esse espaço.
Whitespace is the space before and/or after the actual text, and very often you want to remove this space.

The [ strip() ] method removes any whitespace from the beginning or the end:
PO método [ strip() ] remove qualquer espaço em branco do início ou do fim:
[

a = " Hello, World! "
print(a.strip()) # returns "Hello, World!"

]

                        Replace // Substituir

o método [ replace() ] substitui a string com outro string:
The [ replace() ] method replaces a string with another string:
[

a = "Hello, World!"
print(a.replace("H", "J"))

]

                        Split / Dividir

o método [ split() ] retorna a lista quando o texto entre a um separador específico se torna uma lista de itens
The [ split() ] method returns a list where the text between the specified separator becomes the list items.

o método [ split() ] divide a string em substrings se ele encontra instances no separador
The [ split() ] method splits the string into substrings if it finds instances of the separator:
[

a = "Hello, World!"
print(a.split(",")) # returns ['Hello', ' World!']

]

*/
/* string concaternation

Para concatenar ou combinar duas strings você pode usar o operador +.
To concatenate, or combine, two strings you can use the + operator.

Mesclar variável [ a ] com variável [ b ] em variável [ c ]:
Meerge the variable [ a ] with variable [ b ] in the variable [ c ]
[

a = "Hello"
b = "World"
c = a + b
print(c)

]

for add one space between, add one "" :
Para adicionar um espaço entre eles, adicione um " ":
[

a = "Hello"
b = "World"
c = a + " " + b
print(c)

]
*/
/* string format

como aprendemos eras atrás, na era das cavernas, não podemos combinar número com string assim:
as we learned eons ago, in the cave era, we cannot combine numbers with strings like this:
[

age = 36
txt = "My name is John, I am " + age
print(txt)

]

isso dá erro
that gaves a fuckin error

Mas podemos combinar strings e números usando o método [ format() ]!
PO método [ format() ] pega os argumentos passados, formata-os e os coloca na string onde {} estão os espaços reservados:

But we can combine strings and numbers by using the [ format() ] method!
The [ format() ] method takes the passed arguments, formats them, and places them in the string where the placeholders {} are:
[

age = 15
txt = "My name is Pedro, and I am {}"
print(txt.format(age))

]

PO método [ format() ] aceita um número ilimitado de argumentos e são colocados nos respectivos espaços reservados:
The [ format() ] method takes unlimited number of arguments, and are placed into the respective placeholders:
[

quantity = 3
itemno = 567
price = 49.95
myorder = "I want {} pieces of item {} for {} dollars."
print(myorder.format(quantity, itemno, price))

]

Você pode usar números de índice {0}para garantir que os argumentos sejam colocados nos espaços reservados corretos:
You can use index numbers {0} to be sure the arguments are placed in the correct placeholders:
[

quantity = 3
itemno = 567
price = 49.95
myorder = "I want to pay {2} dollars for {0} pieces of item {1}."
print(myorder.format(quantity, itemno, price))

]

*/
/* string escape

Para inserir caracteres ilegais em uma string, use um caractere de escape.
Um caractere de escape é uma barra invertida \seguida pelo caractere que você deseja inserir.

To insert characters that are illegal in a string, use an escape character.
An escape character is a backslash [ \ ] followed by the character you want to insert.

An example of an illegal character is a double quote inside a string that is surrounded by double quotes:
Um exemplo de caractere ilegal são aspas duplas dentro de uma string entre aspas duplas:
[

txt = "We are the so-called "Vikings" from the north."

]

Para corrigir esse problema, use o caractere de escape \":
To fix this problem, use the escape character \":
[

# PO caractere de escape permite que você use aspas duplas quando normalmente não seria permitido:
# The escape character allows you to use double quotes when you normally would not be allowed:
txt = "We are the so-called \"Vikings\" from the north."

]



*/
/* string escape characters

Outros caracteres de escape usados ​​em Python:
Other escape characters used in Python:
[

 -- \'              Single Quote	
 -- \\              Backslash	
 -- \n              New Line	
 -- \r              Carriage Return	
 -- \t              Tab	
 -- \b              Backspace	
 -- \f              Form Feed	
 -- \ooo            Octal Svalue	
 -- \xhh            Hex Svalue	

]

*/
/* string methods

Python possui um conjunto de métodos integrados que você pode usar em strings.
Python has a set of built-in methods that you can use on strings.

NOTA: Todos os métodos de string retornam novos valores. Eles não alteram a string original.
NOTE: All string methods return new crit_dict_values. They do not change the original string.

capitalize()                Converts the first character to upper case
casefold()                  Converts string into lower case
center()                    Returns a centered string
count()                     Returns the number of times a specified Svalue occurs in a string
encode()	                Returns an encoded version of the string
endswith()	                Returns true if the string ends with the specified Svalue 
expandtabs()	            Sets the tab size of the string
find()	                    Searches the string for a specified Svalue and returns the position of where it was found
format()	                Formats specified crit_dict_values in a string
format_map()	            Formats specified crit_dict_values in a string
index()	                    Searches the string for a specified Svalue and returns the position of where it was found
isalnum()	                Returns True if all characters in the string are alphanumeric
isalpha()	                Returns True if all characters in the string are in the alphabet
isascii()	                Returns True if all characters in the string are ascii characters
isdecimal()	                Returns True if all characters in the string are decimals
isdigit()	                Returns True if all characters in the string are digits
isidentifier()	            Returns True if the string is an identifier
islower()	                Returns True if all characters in the string are lower case
isnumeric()	                Returns True if all characters in the string are numeric
isprintable()	            Returns True if all characters in the string are printable
isspace()	                Returns True if all characters in the string are whitespaces
istitle()	                Returns True if the string follows the rules of a title
isupper()	                Returns True if all characters in the string are upper case
join()	                    Joins the elements of an iterable to the end of the string
ljust()	                    Returns a left justified version of the string
lower()	                    Converts a string into lower case
lstrip()	                Returns a left trim version of the string
maketrans()	                Returns a translation table to be used in translations
partition()	                Returns a tuple where the string is parted into three parts
replace()	                Returns a string where a specified Svalue is replaced with a specified Svalue
rfind()	                    Searches the string for a specified Svalue and returns the last position of where it was found
rindex()	                Searches the string for a specified Svalue and returns the last position of where it was found
rjust()	                    Returns a right justified version of the string
rpartition()	            Returns a tuple where the string is parted into three parts
rsplit()	                Splits the string at the specified separator, and returns a list
rstrip()	                Returns a right trim version of the string
split()	                    Splits the string at the specified separator, and returns a list
splitlines()	            Splits the string at line breaks and returns a list
startswith()	            Returns true if the string starts with the specified Svalue
strip()	                    Returns a trimmed version of the string
swapcase()	                Swaps cases, lower case becomes upper case and vice versa
title()	                    Converts the first character of each word to upper case
translate()	                Returns a translated string
upper()	                    Converts a string into upper case
zfill()	                    Fills the string with a specified number of 0 crit_dict_values at the beginning

*/

#endregion
#region /* bools ...

/* bools

Booleanos representam um de dois valores: [ True ] ou [ False ].
Booleans represent one of two crit_dict_values: True or False.

Na programação, muitas vezes você precisa saber se uma expressão é Trueou False. Você pode avaliar qualquer expressão em Python e obter uma de duas respostas, Trueou False.
In programming you often need to know if an expression is True or False. You can evaluate any expression in Python, and get one of two answers, True or False.

Quando você compara dois valores, a expressão é avaliada e o Python retorna a resposta booleana:
When you compare two crit_dict_values, the expression is evaluated and Python returns the Boolean answer:
[

print(10 > 9)
print(10 == 9)
print(10 < 9)

]

Quando você executa uma condição em uma instrução [ if ], Python retorna [ True ] ou [ False ]:
When you run a condition in an [ if ] statement, Python returns [ True ] or [ False ]:
[

a = 200
b = 33

if b > a:
  print("b is greater than a")
else:
  print("b is not greater than a")

]


*/
/* evaluate bools

A função [ bool() ] permite avaliar qualquer valor e fornecer [ True ] ou [ False ] em troca,
The [ bool() ] function allows you to evaluate any Svalue, and give you [ True ] or [ False ] in return,
[

print(bool("Hello"))
print(bool(15))

]

e em duas variáveis
and in two variables
[

x = "Hello"
y = 15

print(bool(x))
print(bool(y))

]

*/
/* Most crit_dict_values are True

                        PT BR

 -- Quase qualquer valor é avaliado Truese tiver algum tipo de conteúdo
 -- Qualquer string é True, exceto strings vazias.
 -- Qualquer número é True, exceto 0
 -- Qualquer lista, tupla, conjunto e dicionário são True, exceto os vazios.

                        ENG

 -- Almost any Svalue is evaluated to True if it has some sort of content.
 -- Any string is True, except critical strings.
 -- Any number is True, except 0.
 -- Any list, tuple, set, and dictionary are True, except critical ones.


PO seguinte ira retornar [ true ]:
The following will return [ true ]:
[

bool("abc")
bool(123)
bool(["apple", "cherry", "banana"])

]

*/
/* Some crit_dict_values are False

Na verdade, não há muitos valores avaliados como False, exceto valores vazios, como (), [], {}, "", o número [ 0 ] e o valor [ None ]. E é claro que o valor [ False ] é avaliado como [ False ].
In fact, there are not many crit_dict_values that evaluate to False, except critical crit_dict_values, such as (), [], {}, "", the number [ 0 ], and the Svalue [ None ]. And of course the Svalue [ False ] evaluates to [ False ].


PO seguinte retornará [ False ]:
the folowwing will return [ false ]
[

bool(False)
bool(None)
bool(0)
bool("")
bool(())
bool([])
bool({})

]

*/
/* Functions can return a boolean

Você pode criar funções que retornem um valor [ bool ]:
You can create functions that return one [ bool ] Svalue
[

def myFunction():
  return True

print(myFunction())

]

Você pode executar código com base na resposta booleana de uma função:
You can execute code based on the Boolean answer of a function:
[

# imprime "YES!" se o function retorna [ true ], caso contrário, imprime "NO!"
# Print "YES!" if the function returns [ true ], otherwise print "NO!":
def myFunction():
  return True

if myFunction():
  print("YES!")
else:
  print("NO!")

]
Python também possui muitas funções integradas que retornam um valor booleano, como a função [ isinstance() ], que pode ser usada para determinar se um objeto é de um determinado tipo de dados:
Python also has many built-in functions that return a boolean Svalue, like the [ isinstance() ] function, which can be used to determine if an object is of a certain data type:
[

x = 200
print(isinstance(x, int))

]

*/

#endregion
#region /* Operators ...

/* Operators

Operadores são usados ​​para realizar operações em variáveis ​​e valores.
Operators are used to perform operations on variables and crit_dict_values.

No exemplo abaixo, usamos o +operador para somar dois valores:
In the example below, we use the + operator to add together two crit_dict_values:
[

print(10 + 5)

]

                        PT BR

Python divide os operadores nos seguintes grupos:

 -- Operadores aritméticos
 -- Operadores de atribuição
 -- Operadores de comparação
 -- Operadores lógicos
 -- Operadores de identidade
 -- Operadores de adesão
 -- Operadores bit a bit

                        ENG

Python divides the operators in the following groups:

 -- Arithmetic operators
 -- Assignment operators
 -- Comparison operators
 -- Logical operators
 -- Identity operators
 -- Membership operators
 -- Bitwise operatorss



*/
/* Arithmetic Operators

Operadores aritméticos são usados ​​com valores numéricos para realizar operações matemáticas comuns:
Arithmetic operators are used with numeric crit_dict_values to perform common mathematical operations:

                        PT BR

+           Adição                      x + y
-           Subtração                   x - y
*           Multiplicação               x * y
/           Divisão                     x / y
%           Módulo                      x % y
**          Exponenciação               x ** y
//          Divisão do piso             x // y

                        ENG

+	        Addition	                x + y	
-	        Subtraction	                x - y	
*	        Multiplication	            x * y	
/	        Division	                x / y	
%	        Modulus	                    x % y	
**	        Exponentiation	            x ** y	
//	        Floor division	            x // y


*/
/* Comparison Operators

Operadores de comparação são usados ​​para comparar dois valores:
Comparison operators are used to compare two crit_dict_values:

                        PT BR

==              Igual                           x == y	
!=              DIferente                       x != y	
>               Maior que                       x > y	
<	            Menor que       	            x < y	
>=	            Maior que ou igual a	        x >= y	
<=	            Menor que ou igual a	        x <= y

                        ENG


==              Equal                           x == y	
!=              Not equal                       x != y	
>               Greater than                    x > y	
<	            Less than       	            x < y	
>=	            Greater than or equal to	    x >= y	
<=	            Less than or equal to	        x <= y

*/
/* Logical Operators

Operadores lógicos são usados ​​para combinar instruções condicionais:
Logical operators are used to combine conditional statements:

                        PT BR

[ and ]         Retorna [ true ] se ambos as declarações forem [ true ]	                    x < 5 and  x < 10	
[ or ]          Retorna [ true ] se um das declarações for [ true ]	                        x < 5 or x < 4	
[ not ]         Reverte o resultado, retorna [ false ] se o resultado for [ true ]	        not(x < 5 and x < 10)

                        ENG

[ and ]         Returns [ true ] if both statements are [ true ]	                        x < 5 and  x < 10	
[ or ]          Returns [ true ] if one of the statements is [ true ]	                    x < 5 or x < 4	
[ not ]         Reverse the result, returns [ false ] if the result is [ true ]	            not(x < 5 and x < 10)

*/
/* Identificator Operators

Os operadores de identidade são usados ​​para comparar os objetos, não se forem iguais, mas se forem realmente o mesmo objeto, com a mesma localização de memória:
Identity operators are used to compare the objects, not if they are equal, but if they are actually the same object, with the same memory location:

                        PT BR

[ is ]                  Retorna [ true ] se ambos as variáveis são o mesmo objeto                  x is y	
[ is not ]              Retorna [ true ] se ambos as variáveis não são o mesmo objeto              x is not y

                        ENG

[ is ]                  Returns True if both variables are the same object                  x is y	
[ is not ]              Returns True if both variables are not the same object              x is not y


*/
/* Bitwise operators

Operadores bit a bit são usados ​​para comparar números (binários):
Bitwise operators are used to compare (binary) numbers:

                        PT BR

&       AND	                            Sets each bit to 1 if both bits are 1	                                                                        x & y	
|       OR	                            Sets each bit to 1 if one of two bits is 1	                                                                    x | y	
^       XOR	                            Sets each bit to 1 if only one of two bits is 1	                                                                x ^ y	
~       NOT	                            Inverts all the bits	                                                                                        ~x	
<<      Zero fill left shift	        Shift left by pushing zeros in from the right and let the leftmost bits fall off	                            x << 2	
>>      Signed right shift	            Shift right by pushing copies of the leftmost bit in from the left, and let the rightmost bits fall off	        x >> 2


                        ENG

&       AND	                            Sets each bit to 1 if both bits are 1	                                                                        x & y	
|       OR	                            Sets each bit to 1 if one of two bits is 1	                                                                    x | y	
^       XOR	                            Sets each bit to 1 if only one of two bits is 1	                                                                x ^ y	
~       NOT	                            Inverts all the bits	                                                                                        ~x	
<<      Zero fill left shift	        Shift left by pushing zeros in from the right and let the leftmost bits fall off	                            x << 2	
>>      Signed right shift	            Shift right by pushing copies of the leftmost bit in from the left, and let the rightmost bits fall off	        x >> 2



*/
/* Precedence Operator

A precedência do operador descreve a ordem em que as operações são executadas.
Operator precedence describes the order in which operations are performed.
[

# Os parênteses têm a precedência mais alta, o que significa que as expressões entre parênteses devem ser avaliadas primeiro:
# Parentheses has the highest precedence, meaning that expressions inside parentheses must be evaluated first:
print((6 + 3) - (6 + 3))

]

A multiplicação [ * ] tem maior precedência que a adição [ + ] e, portanto, as multiplicações são avaliadas antes das adições:
Multiplication [ * ] has higher precedence than addition [ + ], and therefor multiplications are evaluated before additions:
[

print(100 + 5 * 3)

]



*/
/* Precedence order

A ordem de precedência está descrita na tabela abaixo, começando com a precedência mais alta no topo:
The precedence order is described in the table below, starting with the highest precedence at the top:

                        PT BR

()                                                  Parênteses	
**                                                  Exponenciação	
+x  -x  ~x                                          Unário mais, unário menos e bit a bit NOT
*  /  //  %                                         Multiplicação, divisão, divisão de chão, e módulo	
+  -                                                Soma e Subtração
<<  >>                                              Deslocamentos bit a bit para esquerda e direita	
&                                                   Bitwise AND	
^                                                   Bitwise XOR	
|                                                   Bitwise OR	
==  !=  >  >=  <  <=  is  is not  in  not in        Comparações, identidade e operadores de associação
not	                                                Lógico NÂO	
and	                                                E	
or	                                                OU

Se dois operadores tiverem a mesma precedência, a expressão será avaliada da esquerda para a direita.

                        ENG

()                                                  Parentheses	
**                                                  Exponentiation	
+x  -x  ~x                                          Unary plus, unary minus, and bitwise NOT	
*  /  //  %                                         Multiplication, division, floor division, and modulus	
+  -                                                Addition and subtraction	
<<  >>                                              Bitwise left and right shifts	
&                                                   Bitwise AND	
^                                                   Bitwise XOR	
|                                                   Bitwise OR	
==  !=  >  >=  <  <=  is  is not  in  not in        Comparisons, identity, and membership operators	
not	                                                Logical NOT	
and	                                                AND	
or	                                                OR


If two operators have the same precedence, the expression is evaluated from left to right.

*/

#endregion
#region /* Lists ...

/* Lists

mylist = ["apple", "banana", "cherry"]


As listas são usadas para armazenar vários itens em uma única variável.
Listas são um dos 4 tipos de dados integrados em Python usados ​​para armazenar coleções de dados, os outros 3 são [ Tuple ] , [ Set ] e [ Dictionary ] , todos com qualidades e usos diferentes.

Lists are used to store multiple items in a single variable.
Lists are one of 4 built-in data types in Python used to store collections of data, the other 3 are [ Tuple ], [ Set ], and [ Dictionary ], all with different qualities and usage.

Listas são criados usando colchetes:
Lists are created using square brackets:
[

thislist = ["apple", "banana", "cherry"]
print(thislist)

]

Os itens da lista são ordenados, alteráveis ​​e permitem valores duplicados.
Os itens da lista são indexados, o primeiro item possui index [0], o segundo item possui index [1], etc.

List items are ordered, changeable, and allow duplicate crit_dict_values.
List items are indexed, the first item has index [0], the second item has index [1], etc.


 - Quando dizemos que as listas são ordenadas, significa que os itens têm uma ordem definida e essa ordem não mudará.
    - Se você adicionar novos itens a uma lista, os novos itens serão colocados no final da lista.

 - When we say that lists are ordered, it means that the items have a defined order, and that order will not change.
    - If you add new items to a list, the new items will be placed at the end of the list.


Nota: Existem alguns métodos de lista que irão alterar a ordem, mas em geral: a ordem dos itens não será alterada.
Note: There are some list methods that will change the order, but in general: the order of the items will not change.

*/
/* Changeable and Allow Duplicates


                        CHANGEABLE // ALTERÁVEL

A lista é mutável, o que significa que podemos alterar, adicionar e remover itens de uma lista após ela ter sido criada.
The list is changeable, meaning that we can change, add, and remove items in a list after it has been created.


                        ALLOW DUPLICATES // PERMITIR DUPLICATAS

Como as listas são indexadas, as listas podem ter itens com o mesmo valor:
Since lists are indexed, lists can have items with the same Svalue:
[

thislist = ["apple", "banana", "cherry", "apple", "cherry"]
print(thislist)

]

*/
/* Length

Para determinar quantos itens uma lista possui, use a função [ len() ]:
To determine how many items a list has, use the [ len() ] function:
[

thislist = ["apple", "banana", "cherry"]
print(len(thislist))

]

*/
/* Data Types

Itens de lista podem ser qualquer tipo de dado:
List items can be of any data type:
[

list1 = ["apple", "banana", "cherry"]
list2 = [1, 5, 7, 9, 3]
list3 = [True, False, False]

]

A lista pode conter diferentes tipos de dados:
A list can contain different data types:
[

list1 = ["abc", 34, True, 40, "male"]

]

*/
/* MedalType()

Pela perspectiva do Python, listas são definidos como objetos com o tipo de data [ list ]
From Python's perspective, lists are defined as objects with the data type [ list ]:
[

<class 'list'>

]

Qual é o tipo de dado da lista?
What is the data type of a list?
[

mylist = ["apple", "banana", "cherry"]
print(type(mylist))

]

*/
/* List()

Também é possível usar o construtor [ list() ] ao criar uma nova lista.
It is also possible to use the [ list() ] constructor when creating a new list.

thislist = list(("apple", "banana", "cherry")) # note the double round-brackets // note os dois parênteses
print(thislist)

*/
/* Collection (Arrays)

                        PT BR

Existem quatro tipos de dados de coleta na linguagem de programação Python:

[ List ]        é uma coleção ordenada e alterável. Permite membros duplicados.
[ Tuple ]       é uma coleção ordenada e inalterável. Permite membros duplicados.
[ Set ]         é uma coleção não ordenada, inaterável e não indexada. Nenhum membro duplicado.
[ Dicionary ]   é uma coleção ordenada e alterável. Nenhum membro duplicado.

 -- Os itens do conjunto não podem ser alterados, mas você pode remover e/ou adicionar itens sempre que desejar.
 -- A partir da versão 3.7 do Python, os dicionários são ordenados . No Python 3.6 e anteriores, os dicionários são desordenados .


Ao escolher um tipo de coleção, é útil compreender as propriedades desse tipo.
Escolher o tipo certo para um determinado conjunto de dados pode significar retenção de significado e um aumento na eficiência ou segurança

                        ENG

There are four collection data types in the Python programming language:

[ List ]        is a collection which is ordered and changeable. Allows duplicate members.
[ Tuple ]       is a collection which is ordered and unchangeable. Allows duplicate members.
[ Set ]         is a collection which is unordered, unchangeable*, and unindexed. No duplicate members.
[ Dictionary ]  is a collection which is ordered** and changeable. No duplicate members.


 -- Set items are unchangeable, but you can remove and/or add items whenever you like.
 -- As of Python version 3.7, dictionaries are ordered. In Python 3.6 and earlier, dictionaries are unordered.

When choosing a collection type, it is useful to understand the properties of that type. 
Choosing the right type for a particular data set could mean retention of meaning, and, it could mean an increase in efficiency or security.

*/
/* Lists Index

Os itens da lista são indexados e você pode acessá-los consultando o número do índice:
List items are indexed and you can access them by referring to the index number:
[

thislist = ["apple", "banana", "cherry"]
print(thislist[1])

]

Nota: PO primeiro item possui índice [ 0 ].
Note: the first item has index [ 0 ].

                        Negative Indexing // Indexação Negativa

Indexação negativa significa começar do fim
[ -1 ]refere-se ao último item, [ -2 ] refere-se ao penúltimo item etc.

Negative indexing means start from the end
[ -1 ] refers to the last item, [ -2 ] refers to the second last item etc.
[

thislist = ["apple", "banana", "cherry"]
print(thislist[-1])

]

                        Ranges // Gama

Você pode especificar um intervalo de índices especificando onde começar e onde terminar o intervalo.
Ao especificar um intervalo, o valor de retorno será uma nova lista com os itens especificados. 

You can specify a range of indexes by specifying where to start and where to end the range.
When specifying a range, the return Svalue will be a new list with the specified items.
[

thislist = ["apple", "banana", "cherry", "orange", "kiwi", "melon", "mango"]
print(thislist[2:5])

]

Nota: A pesquisa começará no índice [ 2 ] (incluído) e terminará no índice [ 5 ] (não incluído).
Note: The search will start at index [ 2 ] (included) and end at index [ 5 ] (not included).

Ao omitir o valor inicial, o intervalo começará no primeiro item:
By leaving out the start Svalue, the range will start at the first item:
[

# Este exemplo retorna os itens desde o início, mas NÃO incluindo, [ kiwi ]:
# This example returns the items from the beginning to, but NOT including, [ kiwi ]:
thislist = ["apple", "banana", "cherry", "orange", "kiwi", "melon", "mango"]
print(thislist[:4])

]

Ao omitir o valor final, o intervalo irá para o final da lista:
By leaving out the end Svalue, the range will go on to the end of the list:
[

# Este exemplo retorna os itens de [ cherry ] até o final:
# This example returns the items from [ cherry ] to the end:
thislist = ["apple", "banana", "cherry", "orange", "kiwi", "melon", "mango"]
print(thislist[2:])

]

                        NEGATIVE RANGES // GAMAS NEGATIVOS

Especifique índices negativos se desejar iniciar a pesquisa do final da lista:
Specify negative indexes if you want to start the search from the end of the list:
[

# Este exemplo retorna os itens de [ orange ] (-4) até, mas NÃO inclui [ mango ] (-1):
# This example returns the items from [ orange ] (-4) to, but NOT including [ mango ] (-1):
thislist = ["apple", "banana", "cherry", "orange", "kiwi", "melon", "mango"]
print(thislist[-4:-1])

]

                        IF THE ITEM EXISTS // SE PO ITEM EXISTE

Para determinar se um item especificado está presente em uma lista, use a palavra-chave [ in ]:
To determine if a specified item is present in a list use the [ in ] keyword:
[

thislist = ["apple", "banana", "cherry"]
if "apple" in thislist:
  print("Yes, 'apple' is in the fruits list")

]


*/
/* Change Items Values

                        CHANGING A RANGE // ALTERANDO A GAMA

Para alterar o valor dos itens dentro de um intervalo específico, defina uma lista com os novos valores e consulte o intervalo de números de índice onde deseja inserir os novos valores:
To change the Svalue of items within a specific range, define a list with the new crit_dict_values, and refer to the range of index numbers where you want to insert the new crit_dict_values:
[

# Troque os valores “banana” e “cherry” pelos valores “blackcurrant” e “watermelon”:
# Change the crit_dict_values "banana" and "cherry" with the crit_dict_values "blackcurrant" and "watermelon":
thislist = ["apple", "banana", "cherry", "orange", "kiwi", "mango"]
thislist[1:3] = ["blackcurrant", "watermelon"]
print(thislist) 

]

Se você inserir mais itens do que substitui, os novos itens serão inseridos onde você especificou e os itens restantes serão movidos de acordo:
If you insert more items than you replace, the new items will be inserted where you specified, and the remaining items will move accordingly:
[

# Altere o segundo valor substituindo-o por dois novos valores:
# Change the second Svalue by replacing it with two new crit_dict_values:
thislist = ["apple", "banana", "cherry"]
thislist[1:2] = ["blackcurrant", "watermelon"]
print(thislist)

]

Nota: PO comprimento da lista mudará quando o número de itens inseridos não corresponder ao número de itens substituídos.
Note: The length of the list will change when the number of items inserted does not match the number of items replaced.

Se você inserir menos itens do que substitui, os novos itens serão inseridos onde você especificou e os itens restantes serão movidos de acordo:
[

# Altere o segundo e o terceiro valores substituindo-os por um valor:
# Change the second and third Svalue by replacing it with one Svalue:
thislist = ["apple", "banana", "cherry"]
thislist[1:3] = ["watermelon"]
print(thislist)

]

*/
/* Insert Items

Para inserir um novo item da lista, sem substituir nenhum dos valores existentes, podemos utilizar o método [ insert() ]
To insert a new list item, without replacing any of the existing crit_dict_values, we can use the [ insert() ] method.

PO método [ insert() ] insere um item no índice especificado:
The [ insert() ] method inserts an item at the specified index:
[

# Insere [ Watermelon ] como terceiro item 
# Insert [ Watermelon ] as the third item:
thislist = ["apple", "banana", "cherry"]
thislist.insert(2, "watermelon")
print(thislist)


]

*/
/* Add Items

                        Append Items // Anexar itens

Para adicionar um item ao final da lista, use o método [ append() ]:
To add an item to the end of the list, use the [ append() ] method:
[

thislist = ["apple", "banana", "cherry"]
thislist.append("orange")
print(thislist)

]

                        Extend Lists // Extender Listas

Para acrescentar elementos de outra lista à lista atual, use o método [ extend() ].
To append elements from another list to the current list, use the [ extend() ] method.
[

# Adiciona os elementos de [ tropical ] para [ thislist ]
# Add the elements of [ tropical ] to [ thislist ]:
thislist = ["apple", "banana", "cherry"]
tropical = ["mango", "pineapple", "papaya"]
thislist.extend(tropical)
print(thislist)

]

                        Add Iterables // Adicionar Iteráveis

PO método [ extend()] não precisa anexar listas, você pode adicionar qualquer objeto iterável (tuples, sets, dicionáaries etc.).
The [ extend() ] method does not have to append lists, you can add any iterable object (tuples, sets, dictionaries etc.).

Adiciona elementos de um tuple para a lista:
Add elements of a tuple to a list:
[

thislist = ["apple", "banana", "cherry"]
thistuple = ("kiwi", "orange")
thislist.extend(thistuple)
print(thislist)

]

*/
/* Removes

PO método [ remove() ] remove o item especificado.
The [ remove() ] method removes the specified item.
[

thislist = ["apple", "banana", "cherry"]
thislist.remove("banana")
print(thislist)

]

                        Remove the specific Index // Remove o index específico

o método [ pop() ] remove o index específico
The [ pop() ] method removes the specified index.
[

thislist = ["apple", "banana", "cherry"]
thislist.pop(1)
print(thislist)

]

Se você não especificar o index, o metodo [ pop() ] remove o último item
If you do not specify the index, the [ pop() ] method removes the last item.
[

thislist = ["apple", "banana", "cherry"]
thislist.pop()
print(thislist)

]

a keyword [ del ] também remove o index específico
the [ del ] keyword also removes the specific index
[

thislist = ["apple", "banana", "cherry"]
del thislist[0]
print(thislist)

]

o keyword [ del ] também pode deletar a lista inteira
The [ del ] keyword can also delete the list completely.
[

thislist = ["apple", "banana", "cherry"]
del thislist

]

                        Clear the list // Limpar a lista

o método [ clear() ] esvazia a lista.
a lista ainda existe, mas não tem conteúdo

The [ clear() ] method empties the list.
The list still remains, but it has no content.
[

thislist = ["apple", "banana", "cherry"]
thislist.clear()
print(thislist)

]

*/
/* Loop lists

                        Loop // Loop

Você pode percorrer os itens da lista usando um loop [ for ]:
You can loop through the list items by using a [ for ] loop:
[

# Imprima todos os itens da lista, um por um:
# Print all of the list, one by one
thislist = ["apple", "banana", "cherry"]
for x in thislist:
  print(x)

]

                        Loop in Index Numbers // Percorrer em Números Index

Você também pode percorrer os itens da lista consultando seu número de índice.
Use as funções [ range() ] e [ len() ] para criar um iterável adequado.

You can also loop through the list items by referring to their index number.
Use the [ range() ] and [ len() ] functions to create a suitable iterable.
[

# Imprima todos os itens referindo-se ao seu número de índice:
# Print all items by referring to their index number:
thislist = ["apple", "banana", "cherry"]
for i in range(len(thislist)):
  print(thislist[i])

]

o iterável criado no ecemplo acima é [0, 1, 2].
The iterable created in the example above is [0, 1, 2].


                                While loop // Enquanto loop

Você pode percorrer os itens da lista usando um [ while ] loop.
Use a função [ len() ] para determinar o comprimento da lista, então comece em [ 0 ] e percorra os itens da lista consultando seus índices.

You can loop through the list items by using a while loop.
Use the [ len() ] function to determine the length of the list, then start at [ 0 ] and loop your way through the list items by referring to their indexes.

Lembre-se de aumentar o índice em [ 1 ] após cada iteração.
Remember to increase the index by [ 1 ] after each iteration.
[

# Imprima todos os itens, usando um [ while ] loop para percorrer todos os números de índice
# Print all items, using a [ while ] loop to go through all the index numbers
thislist = ["apple", "banana", "cherry"]
i = 0
while i < len(thislist):
  print(thislist[i])
  i = i + 1

]

                        List Comprehension // Compreensão de Listas

A compreensão de lista oferece a sintaxe mais curta para percorrer listas:
List Comprehension offers the shortest syntax for looping through lists:
[

# Um pequeno [ for ] loop manual que imprimirá todos os itens de uma lista:
# A short hand for loop that will print all items in a list:
thislist = ["apple", "banana", "cherry"]
[print(x) for x in thislist]

]

*/
/* List Comprehension

A compreensão de lista oferece uma sintaxe mais curta quando você deseja criar uma nova lista com base nos valores de uma lista existente.
List comprehension offers a shorter syntax when you want to create a new list based on the crit_dict_values of an existing list.

Com base em uma lista de frutas, deseja-se uma nova lista, contendo apenas as frutas com a letra “a” no nome.
Sem compreensão da lista você terá que escrever uma fordeclaração com um teste condicional dentro:

Based on a list of fruits, you want a new list, containing only the fruits with the letter "a" in the name.
Without list comprehension you will have to write a for statement with a conditional test inside:
[

fruits = ["apple", "banana", "cherry", "kiwi", "mango"]
newlist = []

for x in fruits:
  if "a" in x:
    newlist.append(x)

print(newlist)

]

Com a compreensão de listas você pode fazer tudo isso com apenas uma linha de código:
With list comprehension you can do all that with only one line of code:
[

fruits = ["apple", "banana", "cherry", "kiwi", "mango"]

newlist = [x for x in fruits if "a" in x]

print(newlist)

]

                        Syntax
[

newlist = [expression for item in iterable if condition == True]

]

The return Svalue is a new list, leaving the old list unchanged.
PO valor de retorno é uma nova lista, deixando a lista antiga inalterada.


                        Condition // Condição (google trdutor traduziu isso pra [ doença ], então foi eu que traduzi


A condição é como um filtro que aceita apenas os itens com valor igual a [ true ].
The condition is like a filter that only accepts the items that valuate to [ true ].
[

# Somente aceita itens que não forem "apple":
# Only accept items that are not "apple":
newlist = [x for x in fruits if x != "apple"]

]

A condição [ if x != "apple" ] retornará [ true ] para todos os elementos exceto "apple", fazendo com que a nova lista contenha todas as frutas, exceto "apple".
The condition [ if x != "apple" ] will return [ true ] for all elements other than "apple", making the new list contain all fruits except "apple".

A condição é opcional e pode ser omitida:
the condition its optional and can be omited:
[

# sem [ if ]
# without [ if ]
newlist = [x for x in fruits]

]


                        Iterable // Iterável

PO iterável pode ser qualquer objeto iterável, como uma lista, tupla, conjunto etc.
The iterable can be any iterable object, like a list, tuple, set etc.
[

# Você pode usar a função [ range() ] para criar um iterável:
# You can use the [ range() ] function to create an iterable:

newlist = [x for x in range(10)]

]

Mesmo exemplo, mas com condição
Same example, but with a condition:
[

# Somente aceita números abaixo que [ 5 ]:
# Accept only numbers lower than [ 5 ]:

newlist = [x for x in range(10) if x < 5]

]

                        Expression // Expressão (facial (NOSSA< MELHOR PIADA DO ANO LOL LOL LOL))


A expressão é o item atual na iteração, mas também é o resultado, que você pode manipular antes que acabe como um item de lista na nova lista:
The expression is the current item in the iteration, but it is also the outcome, which you can manipulate before it ends up like a list item in the new list:
[

# Coloca os valores na newlist para maiúsculo:
# Set the crit_dict_values in the new list to upper case:

newlist = [x.upper() for x in fruits]

]

Você pode definir o resultado como quiser:
You can set the outcome to whatever you like:
[

# Defina todos os valores na nova lista como 'hello':
# Set all crit_dict_values in the new list to 'hello':

newlist = ['hello' for x in fruits]

]

A expressão também pode conter condições, não como um filtro, mas como uma forma de manipular o resultado:
The expression can also contain conditions, not like a filter, but as a way to manipulate the outcome:
[

# Retorna [ orange ] inves de [ banana ]
# return [ orange ] instead of [ banana ]

newlist = [x if x != "banana" else "orange" for x in fruits]

]

*/

/* Sort Lists (critical)

*/
/* Copy Lists (critical)

*/
/* Join Lists (critical)

*/
/*Lists Methods (critical)

*/

#endregion

#region bla bla bla (empty)

#endregion

//voltando
//backing
/* if -- else

Python suporta as condições lógicas usuais da matemática:
Python supports the usual logical conditions from mathematics:

 -- igual               // equal:                               a == b
 -- não é igual         // not equal:                           a! = b
 -- Menor que           // less than:                           a < b
 -- Menor ou igual a    // less than or equal to:               a <= b
 -- Maior que           // Greater than:                        a > b
 -- Maior ou igual a    // Greater than or equal to:            a >= b

Essas condições podem ser usadas de diversas maneiras, mais comumente em "instruções if" e loops.
These conditions can be used in several ways, most commonly in "if statements" and loops.
[

# Uma "instrução [ if ]" é escrita usando a palavra-chave [ if ].
# An "[ if ] statement" is written by using the [ if ] keyword.

a = 33
b = 200
if b > a:
  print("b is greater than a")

]

Neste exemplo usamos duas variáveis, a e b , que são usadas como parte da instrução if para testar se b é maior que a .
Como a é 33 e b é 200 , sabemos que 200 é maior que 33 e então imprimimos na tela que "b é maior que a".

In this example we use two variables, a and b, which are used as part of the if statement to test whether b is greater than a.
As a is 33, and b is 200, we know that 200 is greater than 33, and so we print to screen that "b is greater than a".


                        Recoil // Recuo

Python depende de recuo (espaço em branco no início de uma linha) para definir o escopo no código. Outras linguagens de programação costumam usar colchetes para essa finalidade.
Python relies on indentation (whitespace at the beginning of a line) to define scope in the code. Other programming languages often use curly-brackets for this purpose.
[

# Instrução If, sem recuo (irá gerar um erro):
# If statement, without indentation (will raise an error):

a = 33
b = 200
if b > a:
print("b is greater than a") # you will get an error

]

                        ELIFF


A palavra-chave [ elif ] é a maneira do Python dizer "se as condições anteriores não eram verdadeiras, tente esta condição".
The [ elif ] keyword is Python's way of saying "if the previous conditions were not true, then try this condition".
[

a = 33
b = 33
if b > a:
  print("b is greater than a")
elif a == b:
  print("a and b are equal")

]

Neste exemplo, [ a ] é igual a [ b ] , então a primeira condição não é [ true ], mas a condição elif é verdadeira, então imprimimos na tela que "[ a ] e [ b ] são iguais".
In this example, [ a ] is equal to [ b ], so the first condition is not [ true ], but the elif condition is true, so we print to screen that "[ a ] and [ b ] are equal".

                        ELSE

A palavra-chave [ else ] captura qualquer coisa que não seja capturada pelas condições anteriores.
The else keyword catches anything which isn't caught by the preceding conditions.
[

a = 200
b = 33
if b > a:
  print("b is greater than a")
elif a == b:
  print("a and b are equal")
else:
  print("a is greater than b")

]

Neste exemplo, [ a ] é maior que [ b ] , então a primeira condição não é verdadeira, também a condição [ elif ] não é verdadeira, então vamos para a condição else e imprimimos na tela que "a é maior que b".
In this example, [ a ] is greater than [ b ], so the first condition is not true, also the [ elif ] condition is not true, so we go to the else condition and print to screen that "a is greater than b".


Você também pode ter um elsesem [ elif ]:
You can also have an else without the [ elif ]:
[

a = 200
b = 33
if b > a:
  print("b is greater than a")
else:
  print("b is not greater than a")

]

                        Short Hand If // Mão abreviada se

Se você tiver apenas uma instrução para executar, poderá colocá-la na mesma linha da instrução [ if ]. (eu não uso isso. me da agonia usar [ if ] de uma linha)
If you have only one statement to execute, you can put it on the same line as the if statement. (I don't use this. It gives me agony to use one-line [if])
[

if a > b: print("a is greater than b")

]

                        Short Hand If ... Else // Abreviação se... se não

Se você tiver apenas uma instrução para executar, uma para [ if ] e outra para [ else ], poderá colocar tudo na mesma linha:
If you have only one statement to execute, one for [ if ], and one for [ else ], you can put it all on the same line:
[

a = 2
b = 330
print("A") if a > b else print("B")

]

 -- Esta técnica é conhecida como Operadores Ternários ou Expressões Condicionais.
 -- This technique is known as Ternary Operators, or Conditional Expressions.

Você também pode ter várias instruções else na mesma linha:
You can also have multiple else statements on the same line:
[

# Uma linha de [ if ] e  [ else ] com 3 condições:
# One line [ if ] [ else ] statement, with 3 conditions:

a = 330
b = 330
print("A") if a > b else print("=") if a == b else print("B")

]


                        AND // E

A palavra-chave [ and ] é um operador lógico e é usada para combinar instruções condicionais:

The [ and ] keyword is a logical operator, and is used to combine conditional statements:
[


# Teste se [ a ] for maior que [ b ] E se [ c ] for maior que [ a ]:
# Test if [ a ] is greater than [ b ], AND if [ c ] is greater than [ a ]:

a = 200
c = 500
if a > b and c > a:
  print("Both conditions are True")

]

(por SLugg) Resumindo: acontece se ambos estão [ true ]. é isso
(by SLugg) In short: happens if both are [ true ]. and that

                                OR // OU


A palavra-chave [ or ] é um operador lógico e é usada para combinar instruções condicionais:
The [ or ] keyword is a logical operator, and is used to combine conditional statements:
[

# Teste se [ a ] for maior que [ b ], OU se [ a ] for maior que [ c ]:
# Test if [ a ] ​​is greater than [ b ], OR if [ a ] ​​is greater than [ c ]: 

a = 200
b = 33
c = 500
if a > b or a > c:
  print("At least one of the conditions is True")


]

                        NOT // NÃO

A palavra-chave [ not ] é um operador lógico e é usada para reverter o resultado da instrução condicional:
The [ not ] keyword is a logical operator, and is used to reverse the result of the conditional statement:
[

# teste se [ a ] NÃO È maior que [ b ]
# Test if [ a ] is NOT greater than [ b ]:

a = 33
b = 200
if not a > b:
  print("a is NOT greater than b")

]

                        Nested If // if Aninhado (nome engraçado kkkkk)

Você pode ter instruções [ if ] dentro de instruções [ if ], isso é chamado de instruções aninhadas
You can have [ if ] statements inside [ if ] statements, this is called nested if statements.
[

x = 41

if x > 10:
  print("Above ten,")
  if x > 20:
    print("and also above 20!")
  else:
    print("but not above 20.")

]

                    PASS

as instruções [ if ] não podem estar vazias, mas se por algum motivo você tiver uma instrução [ if ] sem conteúdo, coloque-a na instrução [ pass ] para evitar erros.
[ if ] statements cannot be critical, but if you for some reason have an [ if ] statement with no content, put in the [ pass ] statement to avoid getting an error.
[

a = 33
b = 200

if b > a:
  pass

]

*/
/* While Loops

Python tem dois comandos de loop primitivos:
Python has two primitive loop commands:

 -- [ while ] loops
 -- [ for ] loops

                        While

Com o loop while podemos executar um conjunto de instruções, desde que uma condição seja verdadeira.
With the while loop we can execute a set of statements as long as a condition is true.
[

# Print [ i ] as long as [ i ] is less than 6:
# Imprima [ i ] desde que [ i ] seja menor que 6:

i = 1
while i < 6:
  print(i)
  i += 1

]

Nota: lembre-se de incrementar i, caso contrário o loop continuará para sempre.
Note: remember to increment i, or else the loop will continue forever.


PO loop while requer que variáveis ​​relevantes estejam prontas, neste exemplo precisamos definir uma variável de indexação, [ i ] , que definimos como 1.
The while loop requires relevant variables to be ready, in this example we need to define an indexing variable, [ i ], which we set to 1.


                        Break

Com a instrução break podemos parar o loop mesmo se a condição while for verdadeira:
With the break statement we can stop the loop even if the while condition is true:
[

# Quebre o loop quando [ i ] chegar á 3
# 

i = 1
while i < 6:
  print(i)
  if i == 3:
    break
  i += 1

]


                        Continue


Com a instrução [ continue], podemos parar a iteração atual e continuar com a próxima:
With the [ continue ] statement we can stop the current iteration, and continue with the next:
[

# Continue para a próxima iteração se [ i ] for [ 3 ]:
# Continue to the next iteration if [ i ] is [ 3 ]:

i = 0
while i < 6:
  i += 1
  if i == 3:
    continue
  print(i)

]


                        Else


Com a instrução [ else ], podemos executar um bloco de código uma vez quando a condição não for mais verdadeira:
With the [ else ] statement we can run a block of code once when the condition no longer is true:
[

# Imprima uma mensagem quando a condição for falsa:
# Print a message once the condition is false:

i = 1
while i < 6:
  print(i)
  i += 1
else:
  print("i is no longer less than 6")

]

*/
/* For loops


Um loop [ for ] é usado para iterar uma sequência (que é uma lista, uma tupla, um dicionário, um conjunto ou uma string).
Isso é menos parecido com a palavra-chave [ for ] em outras linguagens de programação e funciona mais como um método iterador encontrado em outras linguagens de programação orientadas a objetos.

A [ for ] loop is used for iterating over a sequence (that is either a list, a tuple, a dictionary, a set, or a string).
This is less like the [ for ] keyword in other programming languages, and works more like an iterator method as found in other object-orientated programming languages.
[

fruits = ["apple", "banana", "cherry"]
for x in fruits:
  print(x)

]

PO loop [ for ] não requer que uma variável de indexação seja definida antecipadamente.
The [ for ] loop does not require an indexing variable to set beforehand.

                        Loop in a string

Mesmo que strings são objetos iteráveis, elas contêm uma sequência de caracteres:
Even strings are iterable objects, they contain a sequence of characters:
[

for x in "banana":
  print(x)

]

                        Break

Com a instrução [ break ], podemos parar o loop antes que ele percorra todos os itens:
With the [ break ] statement, we can stop the loop before it has looped through all the items:
[

# Saia do loop quando [ x ] for "banana":
# Exit the loop when [ x ] is "banana":

fruits = ["apple", "banana", "cherry"]
for x in fruits:
  print(x)
  if x == "banana":
    break

]

Sai do loop quando [ x ] for "banana", mas dessa vez o [ break ] vem antes do print:
Exit the loop when [ x ] is "banana", but this time the [ break ] comes before the print:
[

fruits = ["apple", "banana", "cherry"]
for x in fruits:
  if x == "banana":
    break
  print(x)

]

                        Continue

Com a instrução [ continue ], podemos parar a iteração atual do loop e continuar com a próxima:
With the [ continue ] statement, we can stop the current iteration of the loop, and continue with the next:
[

# Não imprime [ slugg ]
# Dont print [ slugg ]

fruits = ["Nuclear Pasta", "slugg", "NaCIO"]
for x in fruits:
  if x == "banana":
    continue
  print(x)

]

                        Range()


                        Else etc


                        Nested


                        Pass


                        

*/
/* Functions

Uma função é um bloco de código que só é executado quando é chamado.
Você pode passar dados, conhecidos como parâmetros, para uma função.
Uma função pode retornar dados como resultado.

A function is a block of code which only runs when it is called.
You can pass data, known as parameters, into a function.
A function can return data as a result.


                        Creating // Criando

Em Python, uma função é definida usando a palavra-chave [ def ]:
In Python a function is defined using the [ def ] keyword:
[

def my_function():
    print("Hello there!! OwO")

]


                        Calling // Chamando

Para chamar uma função, use o nome da função seguido de parênteses:
To call a function, use the function name followed by parenthesis:
[

def my_function():
    print("Hello there!! OwO")


my_function() #cal the function // chama a função

]

                        Arguments // Argumentos

As informações podem ser passadas para funções como argumentos.
Os argumentos são especificados após o nome da função, entre parênteses. Você pode adicionar quantos argumentos quiser, basta separá-los com vírgula.

Information can be passed into functions as arguments.
Arguments are specified after the function name, inside the parentheses. You can add as many arguments as you want, just separate them with a comma.

PO exemplo a seguir possui uma função com um argumento (fname). Quando a função é chamada, passamos um primeiro nome, que é usado dentro da função para imprimir o nome completo:
The following example has a function with one argument (fname). When the function is called, we pass along a first name, which is used inside the function to print the full name:
[

def my_function(fname):
  print(fname + " Refsnes")

my_function("Emil")
my_function("Tobias")
my_function("Linus")

]

Os argumentos são frequentemente abreviados para args nas documentações do Python.
Arguments are often shortened to args in Python documentations.

                        Parameters or Arguments? // Parâmetros ou argumentos?


Os termos parâmetro e argumento podem ser usados ​​para a mesma coisa: informações que são passadas para uma função.
The terms parameter and argument can be used for the same thing: information that are passed into a function.

                PT BR

Da perspectiva de uma função:

 -- Um parâmetro é a variável listada entre parênteses na definição da função.
 -- Um argumento é o valor enviado à função quando ela é chamada.

                ENG

From a function's perspective:

 -- A parameter is the variable listed inside the parentheses in the function definition.
 -- An argument is the Svalue that is sent to the function when it is called.


                        Argument Number // Número de argumentos

Por padrão, uma função deve ser chamada com o número correto de argumentos. PO que significa que se sua função espera 2 argumentos, você deve chamar a função com 2 argumentos, nem mais, nem menos.
By default, a function must be called with the correct number of arguments. Meaning that if your function expects 2 arguments, you have to call the function with 2 arguments, not more, and not less.

Esta função espera 2 argumentos e obtém 2 argumentos:
This function expects 2 arguments, and gets 2 arguments:
[

def my_function(fname, lname):
  print(fname + " " + lname)

my_function("Emil", "Refsnes")

]

Se você tentar chamar a função com 1 ou 3 argumentos, receberá um erro:
If you try to call the function with 1 or 3 arguments, you will get an error:
[

def my_function(fname, lname):
  print(fname + " " + lname)

my_function("Emil")

]


                        *Args

Se você não sabe quantos argumentos serão passados ​​para sua função, adicione um [ * ] antes do nome do parâmetro na definição da função.
Desta forma a função receberá uma tupla de argumentos, e poderá acessar os itens de acordo:

If you do not know how many arguments that will be passed into your function, add a [ * ] before the parameter name in the function definition.
This way the function will receive a tuple of arguments, and can access the items accordingly:
[

def my_function(*kids):
  print("The youngest child is " + kids[2])

my_function("Emil", "Tobias", "Linus")

]

Argumentos arbitrários são frequentemente abreviados para [ *args ] nas documentações do Python.
Arbitrary Arguments are often shortened to [ *args ] in Python documentations



                        Keyword Args

Você também pode enviar argumentos com a sintaxe [ chave = valor ].
Desta forma, a ordem dos argumentos não importa.

You can also send arguments with the [ key = Svalue ] syntax.
This way the order of the arguments does not matter.
[

def my_function(child3, child2, child1):
  print("The youngest child is " + child3)

my_function(child1 = "Emil", child2 = "Tobias", child3 = "Linus")

]

A frase Argumentos de palavras-chave costuma ser abreviada para [ kwargs ] nas documentações do Python.
The phrase Keyword Arguments are often shortened to [ kwargs ] in Python documentations.


                        *Kwargs

//vazio
//critical


                        Default Value (i love this way) // Valor Padrão (eu amo essa forma)

PO exemplo a seguir mostra como usar um valor de parâmetro padrão.
Se chamarmos a função sem argumento, ela usará o valor padrão:

The following example shows how to use a default parameter Svalue.
If we call the function without argument, it uses the default Svalue:
[

def my_function(country = "Norway"):
  print("I am from " + country)

my_function("Sweden")
my_function("India")
my_function()
my_function("Brazil")

]

                        Passing a List as an Argument // Passando a lista como Argumentos

//vazio
//critical


                        Return Values //Retornar valores


Para permitir que uma função retorne um valor, use a [ return ] instrução:
To let a function return a Svalue, use the [ return ] statement:
[

def my_function(x):
  return 5 * x

print(my_function(3))
print(my_function(5))
print(my_function(9))

]

                        PASS

as definições [ function ] não podem ficar vazias, mas se por algum motivo você tiver uma definição [ function ] sem conteúdo, coloque-a na instrução [ pass ] para evitar erro.
[ function ] definitions cannot be critical, but if you for some reason have a [ function ] definition with no content, put in the [ pass ] statement to avoid getting an error.
[

def myfunction():
  pass

]

                        Positional-Only Argument // Argumentos somente Posicionais

//vazio
//critical


                        Keyword-Only Arguments // somente Argumentos de Keywords

//vazio
//critical


                        Combine Positional-Only and Keyword-Only // Combine somente posicional e somente palavra-chave

//vazio
//critical


                        Recursion // Recursão

Python também aceita recursão de função, o que significa que uma função definida pode chamar a si mesma.
A recursão é um conceito matemático e de programação comum. Isso significa que uma função chama a si mesma. Isso tem a vantagem de significar que você pode percorrer os dados para chegar a um resultado.

PO desenvolvedor deve ter muito cuidado com a recursão, pois pode ser muito fácil escrever uma função que nunca termina ou que usa quantidades excessivas de memória ou potência do processador. No entanto, quando escrita corretamente, a recursão pode ser uma abordagem de programação muito eficiente e matematicamente elegante.
Neste exemplo, tri_recursion() é uma função que definimos para chamar a si mesma ("recurse"). Usamos a variável k como dados, que diminui ( -1 ) toda vez que recorremos. A recursão termina quando a condição não é maior que 0 (ou seja, quando é 0).
Para um novo desenvolvedor, pode levar algum tempo para descobrir exatamente como isso funciona. A melhor maneira de descobrir é testando e modificando-o.

Python also accepts function recursion, which means a defined function can call itself.
Recursion is a common mathematical and programming concept. It means that a function calls itself. This has the benefit of meaning that you can loop through data to reach a result.

The developer should be very careful with recursion as it can be quite easy to slip into writing a function which never terminates, or one that uses excess amounts of memory or processor power. However, when written correctly recursion can be a very efficient and mathematically-elegant approach to programming.
In this example, tri_recursion() is a function that we have defined to call itself ("recurse"). We use the k variable as the data, which decrements (-1) every time we recurse. The recursion ends when the condition is not greater than 0 (i.e. when it is 0).
To a new developer it can take some time to work out how exactly this works, best way to find out is by testing and modifying it.
[

def tri_recursion(k):
  if(k > 0):
    result = k + tri_recursion(k - 1)
    print(result)
  else:
    result = 0
  return result

print("\n\nRecursion Example Results")
tri_recursion(6)

]


*/
/* Lambda (critical)

*/
/* Arrays

//Python nem tem Array, mas pode usar List no lugar. Lembre de ler aquilo de novo (se tu quiser)
//Python doesnt have Array. but you can use List instead. Remember to read that again(if you want)

*/
/* Class / Objects



*/

#endregion

#region FIle Hangle

/* Files

A função principal para trabalhar com arquivos em Python é a função [ open() ].
A função [ open() ] leva dois parâmetros; nome do arquivo e modo .
Existem quatro métodos (modos) diferentes para abrir um arquivo:

The key function for working with files in Python is the [ open() ] function.
The [ open() ] function takes two parameters; filename, and mode.
There are four different methods (modes) for opening a file_check:
[

                        PT BR


[ "r" ] - Ler - Valor padrão. Abre um arquivo para leitura, erro se o arquivo não existir

[ "a" ] - Anexar - Abre um arquivo para anexar, cria o arquivo se ele não existir

[ "w" ] - Write - Abre um arquivo para gravação, cria o arquivo caso ele não exista

[ "x" ] - Criar - Cria o arquivo especificado, retorna um erro se o arquivo existir



# Além disso você poderá especificar se o arquivo deverá ser tratado como modo [ binário ] ou [ texto ]

[ "t" ] - Texto - Valor padrão. Modo texto

[ "b" ] - Binário - Modo binário (por exemplo, imagens)


                        ENG

[ "r" ] - Read - Default Svalue. Opens a file_check for reading, error if the file_check does not exist

[ "a" ] - Append - Opens a file_check for appending, creates the file_check if it does not exist

[ "w" ] - Write - Opens a file_check for writing, creates the file_check if it does not exist

[ "x" ] - Create - Creates the specified file_check, returns an error if the file_check exists

# In addition you can specify if the file_check should be handled as binary or text mode

[ "t" ] - Text - Default Svalue. Text mode

[ "b" ] - Binary - Binary mode (e.g. images)

]

                        Sintaxe

Para abrir um arquivo para leitura basta especificar o nome do arquivo:
To open a file_check for reading it is enough to specify the name of the file_check:
[

f = open("demofile.txt")

# PO código acima é igual a:
# The code above is the same as:

f = open("demofile.txt", "rt")

]

Because [ "r" ] for read, and [ "t"  ] for text are the default crit_dict_values, you do not need to specify them.
Como [ "r" ] for read e [ "t" ] for text são os valores padrão, não é necessário especificá-los.

Nota: Certifique-se de que o arquivo exista, caso contrário você receberá um erro.
Note: Make sure the file_check exists, or else you will get an error.


*/

#endregion


#endregion
