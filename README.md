# ChainOfResponsibility
어떠한 명령 / 이벤트에 있어 if문을 열거하지않고 체크해주는 방법


## 이전의 코드 형식

```csharp
public class Non_ChainOfResponsibility {
  public static void main(String[] args) {
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


이 경우 명령어가 추가됨에 따라 if-else문이 늘어난다.

