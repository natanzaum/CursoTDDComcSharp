# **Curso TDD Com C Sharp**     
  
Aplicação para administrar curso online  
  
## **Dominios:**
* Curso, aluno e matricula  
  
### **Curso:**    
* Deve ter um nome, carga horaria, publico alvo e valor  
* Não deve ser salvo com o mesmo nome de outro curso  
  
### **Aluno:**    
* deve ter nome, cpf, data de nascimento e publico alvo a que ele pertence  
* Não deve permitir dois alunos com o mesmo CPF  
  
### **Matricula:**    
* Para efetuar a matricula é necessario informar o curso, aluno e valor pago no curso  
* Um aluno nao pode efetuar uma nova matricula com outra em aberto  
* Alguns alunos tem desconto no valor  
* Publico alvo do aluno e o do curso devem ser o mesmo  
  
### **O que não fazer em teste de unidade:**  
* Testar banco de dados, email e outras coisas externas  
* Escreves testes que dependem de outros testes  
* Escrever nomes de teste inadequados  
* Fazer multiplos asserts (Varios asserts podem prejudicar a leitura e se um dels falhar não vai saber o que deu erro)    
* Atingir 100% de cobertura (Ideal entre 60 - 80 %)  
* Não cuidar dos testes como o código de Produção  
* Não escutar os testes (Não deixar mais de uma responsabilidade no teste)    
  
### **Teste de unidade:**  
* Testa uma única unidade. Ele testa de maneira isolada, geralmente simulando dependências   
  
### **Domínio**  
* Representa conceitos, régras e logicas de negócio   
* Entidade: Tudo aquilo que é identificavel   
* Objeto de valor: Não tem identificador, mas faz parte de uma entidade  
* Por onde começar o teste: Pelos domínios  





