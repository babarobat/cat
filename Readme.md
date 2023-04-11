# Cat  
#### Задача:
Создать симулятор поведения кота
#### Требования
- проект должен быт разделен на 2 сцены - загрузочная и непосредстенно сцена поведения  
- Кот может иметь разное натроение  
- В зависимости от настроения, кот по разному реагирует на действия пользователя
- Добавлять новые действия, реакции и настроения должно быть просто и интиутивно

## Декомпозиция
- логика загрузки приложения. 
  - Создание, инициализация и композиция игровых зависимостей
  - Логика менеджмента состояний приложения
- Система конфигурираций для настройки сущностей
- Логика поведения кота

## Реализация
unity 2021.3.20f  
android  
1080x1920  
- точка входа - Bootstrap.cs
- для контроля состояний приложеия используется StateMachine.cs
- настройка сущностей происходит с помощью ScriptableObject. В дальнейшем они могут быть заменены на таблицы, xml или любой другой формат.
  - для конфигурирования выделены следующие сущности:
    - UserAction.cs - действие игрока
    - CatAction.cs - действие кота
    - CatMood.cs - состояние кота. В нем описаны реакции на действия игрока и переходы в другие состояния в зависимсоти от них
  - дизайнер может добавить или изменить поведение без участия программиста. Изменение конфигураций не требует пересборки билда и выгрузки в стор.
- логика описана в классе CatBehaviour.cs
  - Для каждого состояние выделен отдельный класс. 
  - Состояния изолированы друг от друга. Новое состояние легко добавить, а уже имеющиеся - расширить.
  - Код в состояниях дублируется намеренно в целях демонстрации. В реальном проекте общую часть можно убрать в базовый класс и работать в каждом из состояний только со спецефической логикой
- Данные, которые могу понадобиться между сессиями и имеют глобальный характер вынесены в Model.cs
- Для работы с динамическими данными и бизнес логикой выделен класс Model.cs