## This is a challenge for an ATM machine
    
    Task:
    To design an Automatic Teller Machine (ATM) model.
    There are 5 currency boxes in the ATM in total and all the currency notes are stored in descending
    order.
    There’s following limitations: ATM is supposed to issue no more than 2 notes from the first 2 boxes. On
    the screen display there should be a message of how many and what notes will be issued and an error
    message in case of incorrect pin or lack of notes in the currency boxes.
    You should implement class library for ATM machine (GUI or web interface are not necessary).

### Correct PIN
    
    123

### Input amount samples

     * Should dispense:
     * 197
     * Should not dispense:
     * 123, 126

### Chain of Responsibility Design Pattern

I decide to use the Chain of Responsibility Design Pattern because the object can decide who will be processing the dispensing and whether it will be necessary to send it to the next object in the chain. I applied the rule of the task by limiting the first two currencies.
I applied pin validation with "while" so you can try a lot of password without closing the console application.
    

### Thank you for the challenge and be free to give me a nice feedback!
