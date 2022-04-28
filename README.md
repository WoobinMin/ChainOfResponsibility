# ChainOfResponsibility
어떠한 명령 / 이벤트에 있어 if문을 열거하지않고 체크해주는 방법


## 이전의 코드 형식

```csharp
public class Non_ChainOfResponsibility {
  public static void Main(String[] args) {
    whlie(true)
    {
      string command = Console.ReadLine();
      string firstWord = command.Split(' ')[0];
      
      if(firstWord.Equals("SomeWord1")) {  // Do Your Stuff1  }
      else if(firstWord.Equals("SomeWord2")) {  // Do Your Stuff2  }
      else if(firstWord.Equals("SomeWord3")) {  // Do Your Stuff3  }
      ...
    }
  }

}
```


이 경우 명령어가 추가됨에 따라 if-else문이 늘어난다. 그러면서 명령어가 늘어나면 리스너클래스의 수정도 불가피하다.

이와 같은 if-else열거를 해결하고, 명령어가 늘어나는 변경에 대해 리스너 클래스를 닫는 방법으로 ChainOfResposibility를 사용해봤다.

## ChainOfResposibility
### 우선 명령이 실행가능한지와 어떤 명령을 실행할지에 대한 CommandHandler 인터페이스를 둔다.
```csharp
public interface CommandHandler
{
    bool IsSupport(string _command);
    void Execute(params string[] _commands);
}
```

### 이 후 간단하게 Echo 뒤쪽에 인자로 들어온 말을 console에 뽑아주는 기능을 하는 클래스를 구현
*당연하지만 해당 클래스는 CommandHandler를 상속*
```csharp
class EchoCommand : CommandHandler
{
    public void Execute(params string[] _commands)
    {
        Console.Write("Echo : ");
        for (int i = 1; i < _commands.Length; i++)
            Console.Write($"{_commands[i]} ");
        Console.WriteLine();
    }

    public bool IsSupport(string _command)
    {
        return _command.Split(' ').Length >= 2 && _command.Split(' ')[0].Equals("Echo");
    }
}
```

### 이 후 바뀐코드는 아래와 같다
*DI는 하지않음*


```csharp
public class ChainOfResponsibility {
  List<CommandHandler> commandHandlers;
  
  public ChainOfResponsibility()
  {
    commandHandlers = new List<CommandHandler>();
    
    // 이곳에서 구현한 클래스들을 넣어줌
    commandHandlers.Add(new EchoCommand());
  }


  public static void Main(String[] args) {
    whlie(true)
    {
      string command = Console.ReadLine();
      foreach(var commandHandler in commandHandlers)
      {
        if(commandHandler.IsSupport(command));
          commandHandler.Execute(command.Split(' '));
      }
    }
  }

}
```
