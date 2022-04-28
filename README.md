# ChainOfResponsibility
어떠한 명령 / 이벤트에 있어 if문을 열거하지않고 체크해주는 방법


# 이전의 코드 형식

```c
public class Non_ChainOfResponsibility {
  public static void main(String[] args) {
    whlie(true)
    {
      string command = Console.ReadLine();
      string firstWord = command.Split(' ')[0];
      
      if(firstWord.Equals(" *word1* ")) {  // Do Your Stuff1  }
      else if(firstWord.Equals(" *word2* ")) {  // Do Your Stuff2  }
      else if(firstWord.Equals(" *word3* ")) {  // Do Your Stuff3  }
      ...
    }
  }

}
```
