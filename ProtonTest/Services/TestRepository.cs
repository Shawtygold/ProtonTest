using System;
using System.Collections.Generic;
using System.Text;

namespace ProtonTest.Services
{
    public static class TestRepository
    {
        public static List<TestCategory> GetCategories()
        {
            return new List<TestCategory>
            {
                new TestCategory
                {
                    Id = "fire",
                    Title = "Пожарная безопасность",
                    Description = "Проверка знаний правил пожарного режима, первичных средств тушения и эвакуации.",
                    Questions = GetFireQuestions()
                },
                new TestCategory
                {
                    Id = "civil",
                    Title = "Гражданская оборона (ГО)",
                    Description = "Действия при чрезвычайных ситуациях, сигналы оповещения и применение СИЗ.",
                    Questions = GetCivilQuestions()
                },
                new TestCategory
                {
                    Id = "firstaid",
                    Title = "Первая помощь",
                    Description = "Оказание доврачебной помощи при травмах, ожогах и неотложных состояниях.",
                    Questions = GetFirstAidQuestions()
                },
                new TestCategory
                {
                    Id = "labor",
                    Title = "Охрана труда",
                    Description = "Требования охраны труда, инструктажи, СИЗ и расследование несчастных случаев.",
                    Questions = GetLaborQuestions()
                }
            };
        }

        // =========================================================
        // ПОЖАРНАЯ БЕЗОПАСНОСТЬ
        // =========================================================
        private static List<Question> GetFireQuestions()
        {
            return new List<Question>
            {
                new Question
                {
                    QuestionText = "Что нужно сделать в первую очередь при обнаружении признаков горения (задымления, запаха гари) на своем рабочем месте в цехе?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Позвонить в пожарную охрану (101 или 112) и сообщить руководству цеха", IsCorrect = true },
                        new Option { Text = "Самостоятельно попытаться разобрать электрощит и найти источник искрения", IsCorrect = false },
                        new Option { Text = "Продолжать выполнять производственную операцию до окончания смены", IsCorrect = false },
                        new Option { Text = "Спрятаться в бытовом помещении и закрыть дверь", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какой первичный средство тушения наиболее универсально для тушения электрооборудования под напряжением до 1000 В?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Обычное ведро с водой из подсобки", IsCorrect = false },
                        new Option { Text = "Порошковый или углекислотный огнетушитель", IsCorrect = true },
                        new Option { Text = "Пенный огнетушитель", IsCorrect = false },
                        new Option { Text = "Мокрая ветошь", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что предписывает делать инструкция при срабатывании автоматической пожарной сигнализации в производственном корпусе?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Игнорировать звуковой сигнал, так как это частые ложные срабатывания", IsCorrect = false },
                        new Option { Text = "Прекратить работу, отключить электроприборы и организованно выйти по путям эвакуации", IsCorrect = true },
                        new Option { Text = "Закрыть рабочее место на ключ и оставаться на месте", IsCorrect = false },
                        new Option { Text = "Самостоятельно искать очаг возгорания по всему цеху", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какой знак указывает направление движения к эвакуационному выходу в цехе?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Красный круг с перечеркнутой сигаретой", IsCorrect = false },
                        new Option { Text = "Зеленый прямоугольник со стрелкой и бегущим человеком", IsCorrect = true },
                        new Option { Text = "Синий круг с изображением каски", IsCorrect = false },
                        new Option { Text = "Желтый треугольник с черной молнией", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Где на территории завода разрешено курение?",
                    Options = new List<Option>
                    {
                        new Option { Text = "В любом месте цеха во время перерыва", IsCorrect = false },
                        new Option { Text = "Возле станков и складов материалов", IsCorrect = false },
                        new Option { Text = "Только в специально отведенных и оборудованных местах со знаком «Место для курения»", IsCorrect = true },
                        new Option { Text = "На лестничных клетках эвакуационных выходов", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что запрещается делать при очистке деталей или узлов оборудования от масел и загрязнений?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Использовать специальные сертифицированные моющие технические средства", IsCorrect = false },
                        new Option { Text = "Применять легкогорючие жидкости (бензин, растворители) в не предназначенных емкостях", IsCorrect = true },
                        new Option { Text = "Применять ветошь без ворса", IsCorrect = false },
                        new Option { Text = "Использовать сжатый воздух через штатные пистолеты", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что является главной опасностью для человека в первые минуты пожара в закрытом цехе?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Высокая температура воздуха у потолка", IsCorrect = false },
                        new Option { Text = "Токсичные продукты горения и угарный газ (дым)", IsCorrect = true },
                        new Option { Text = "Обрушение кровли здания", IsCorrect = false },
                        new Option { Text = "Отключение освещения", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Каково назначение пожарного щита на производственном участке?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Хранение инвентаря для уборки цеха", IsCorrect = false },
                        new Option { Text = "Размещение первичных средств пожаротушения, инструмента и инвентаря", IsCorrect = true },
                        new Option { Text = "Использование в качестве скамейки во время перерыва", IsCorrect = false },
                        new Option { Text = "Размещение рабочей одежды сотрудников", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Кто несет персональную ответственность за соблюдение пожарной безопасности в конкретном производственном цехе?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Уборщик производственных помещений", IsCorrect = false },
                        new Option { Text = "Начальник цеха (или лицо, его заменяющее)", IsCorrect = true },
                        new Option { Text = "Специалист отдела кадров", IsCorrect = false },
                        new Option { Text = "Сторож на проходной", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Как часто работник завода должен проходить инструктаж по пожарной безопасности на рабочем месте?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Один раз при приеме на работу и больше никогда", IsCorrect = false },
                        new Option { Text = "Регулярно согласно графику и утвержденным на предприятии порядкам", IsCorrect = true },
                        new Option { Text = "Только по личному желанию работника", IsCorrect = false },
                        new Option { Text = "Только при смене фамилии", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что нужно сделать с промасленной ветошью после окончания работы на станке?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Бросить под верстак, чтобы не мешала", IsCorrect = false },
                        new Option { Text = "Сложить в специальный металлический ящик с крышкой для утилизации", IsCorrect = true },
                        new Option { Text = "Убрать в карман рабочей спецодежды", IsCorrect = false },
                        new Option { Text = "Выбросить в обычную урну с бумажным мусором", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какое требование предъявляется к путям эвакуации (проходам, коридорам) в производственном цехе?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Допускается временное складирование деталей на 2-3 часа", IsCorrect = false },
                        new Option { Text = "Пути эвакуации должны быть всегда свободными, незагроможденными и иметь требуемую ширину", IsCorrect = true },
                        new Option { Text = "Разрешается перекрывать проходы тележками в ночную смену", IsCorrect = false },
                        new Option { Text = "Ширина проходов не имеет значения", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какой огнетушитель используется для тушения твердых горючих материалов (дерево, бумага) в цехе?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Порошковый или водный/пенный", IsCorrect = true },
                        new Option { Text = "Только углекислотный", IsCorrect = false },
                        new Option { Text = "Любой баллон со сжатым воздухом", IsCorrect = false },
                        new Option { Text = "Огнетушители не нужны, достаточно песка", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что обязан сделать работник после успешной эвакуации из горящего цеха на сборный пункт?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Самовольно уйти домой", IsCorrect = false },
                        new Option { Text = "Пройти перекличку у своего мастера или ответственного за эвакуацию", IsCorrect = true },
                        new Option { Text = "Вернуться в цех за оставленной курткой", IsCorrect = false },
                        new Option { Text = "Ждать на проходной без отметки", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какая температура воспламенения жидкостей относит их к легковоспламеняющимся (ЛВЖ)?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Выше 100 °C", IsCorrect = false },
                        new Option { Text = "Низкая температура вспышки (как правило, не выше 61 °C в закрытом тигле)", IsCorrect = true },
                        new Option { Text = "Только при кипении выше 300 °C", IsCorrect = false },
                        new Option { Text = "Температура значения не имеет", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Согласно правилам пожарного режима, с какой периодичностью на взрывопожароопасных участках завода проверяется исправность систем пожаротушения?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Ежегодно", IsCorrect = false },
                        new Option { Text = "Не реже 1 раза в квартал с внесением записей в журнал", IsCorrect = true },
                        new Option { Text = "Только при капитальном ремонте", IsCorrect = false },
                        new Option { Text = "Каждую смену", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что необходимо предпринять при проведении временных огневых работ (сварка) на действующем производственном участке?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Работать без оформления документов, если сварка длится менее 10 минут", IsCorrect = false },
                        new Option { Text = "Оформить наряд-допуск, убрать горючие материалы в радиусе не менее 5 метров и подготовить средства пожаротушения", IsCorrect = true },
                        new Option { Text = "Просто прикрыть станки брезентом без очистки зоны", IsCorrect = false },
                        new Option { Text = "Попросить соседа по цеху присмотреть с ведром воды", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Каковы требования к дверям эвакуационных выходов из цеха с одновременным пребыванием более 50 человек?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Должны открываться внутрь помещения для экономии места", IsCorrect = false },
                        new Option { Text = "Должны открываться наружу по направлению выхода и не иметь замков, не открываемых изнутри без ключа", IsCorrect = true },
                        new Option { Text = "Могут быть заперты на навесные замки в рабочее время", IsCorrect = false },
                        new Option { Text = "Должны быть исключительно раздвижными автоматическими", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какой тип пожарных извещателей наиболее эффективен для обнаружения раннего задымления в кабельных коробах производственного цеха?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Тепловой максимальный", IsCorrect = false },
                        new Option { Text = "Дымовой оптико-электронный", IsCorrect = true },
                        new Option { Text = "Ручной извещатель", IsCorrect = false },
                        new Option { Text = "Световой извещатель пламени", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какое минимальное расстояние требуется выдерживать от мест проведения электросварки до сгораемых материалов, если они не защищены?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Не менее 1 метра", IsCorrect = false },
                        new Option { Text = "Не менее 5 метров", IsCorrect = true },
                        new Option { Text = "Достаточно 50 сантиметров", IsCorrect = false },
                        new Option { Text = "Расстояние не нормируется", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что предписывают правила содержания подвальных и цокольных этажей производственных зданий завода?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Разрешено хранение легковоспламеняющихся жидкостей в любых объемах", IsCorrect = false },
                        new Option { Text = "Запрещено хранение и применение ЛВЖ, баллонов с газами, если это не предусмотрено проектом", IsCorrect = true },
                        new Option { Text = "Разрешено устраивать склады лаков и красок без ограничений", IsCorrect = false },
                        new Option { Text = "Требования к подвалам отсутствуют", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Каким документом оформляется проверка работоспособности систем противопожарной защиты завода спецорганизацией?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Устным докладом начальнику цеха", IsCorrect = false },
                        new Option { Text = "Актом испытаний и проверки с внесением сведений в эксплуатационный журнал", IsCorrect = true },
                        new Option { Text = "Записью в личной медицинской книжке работника", IsCorrect = false },
                        new Option { Text = "Бухгалтерской накладной на оплату услуг", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Каковы нормативные требования к высоте размещения переносных огнетушителей с массой корпуса менее 15 кг?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Верх огнетушителя должен располагаться на высоте не более 1,5 метра от пола", IsCorrect = true },
                        new Option { Text = "Исключительно на полу без крепления", IsCorrect = false },
                        new Option { Text = "На высоте не менее 2,5 метров", IsCorrect = false },
                        new Option { Text = "Внутри производственных шкафов под замком", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что запрещается делать при эксплуатации переносного электроинструмента в цехе по условиям пожарной безопасности?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Использовать инструмент с поврежденной изоляцией кабеля или трещинами корпуса", IsCorrect = true },
                        new Option { Text = "Подключать через исправные удлинители", IsCorrect = false },
                        new Option { Text = "Проводить проверку перед началом смены", IsCorrect = false },
                        new Option { Text = "Работать в сухих перчатках", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какая категория помещений по взрывопожарной опасности присваивается участку с использованием горючих жидкостей с температурой вспышки выше 61 °C в закрытых сосудах, которые могут нагреваться?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Категория А (повышенная взрывопожароопасность)", IsCorrect = false },
                        new Option { Text = "Категория В1–В4 (пожароопасность)", IsCorrect = true },
                        new Option { Text = "Категория Г (умеренная негорючая)", IsCorrect = false },
                        new Option { Text = "Категория Д (негорючие вещества)", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какое требование предъявляется к отделочным материалам на путях эвакуации (коридорах, лестницах) в производственных корпусах?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Допускается отделка любым пластиком", IsCorrect = false },
                        new Option { Text = "Применение строительных материалов с высокой пожарной опасностью строго запрещено", IsCorrect = true },
                        new Option { Text = "Материалы отделки вообще не нормируются", IsCorrect = false },
                        new Option { Text = "Разрешено использовать ковролин с ворсом", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Каков порядок действий при тушении загоревшейся электропроводки под напряжением с помощью порошкового огнетушителя?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Направить струю порошка в очаг горения, соблюдая безопасную дистанцию (не менее 1 метра)", IsCorrect = true },
                        new Option { Text = "Залить водой под большим напором", IsCorrect = false },
                        new Option { Text = "Тушить голыми руками", IsCorrect = false },
                        new Option { Text = "Сначала обрезать провода зубилом под напряжением", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какая периодичность эксплуатационных испытаний пожарных лестниц и ограждений на крышах производственных зданий завода установлена нормами?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Не реже 1 раза в 5 лет", IsCorrect = true },
                        new Option { Text = "Каждый месяц", IsCorrect = false },
                        new Option { Text = "Один раз в 25 лет", IsCorrect = false },
                        new Option { Text = "Испытания не проводятся после постройки", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что обязаны сделать работники ремонтно-строительной бригады при выявлении несоответствия фактической схемы прокладки кабелей проекту пожарной безопасности?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Проигнорировать, если работы уже оплачены", IsCorrect = false },
                        new Option { Text = "Приостановить работы и поставить в известность ответственного за пожарную безопасность", IsCorrect = true },
                        new Option { Text = "Самостоятельно перерезать лишние кабели", IsCorrect = false },
                        new Option { Text = "Замазать кабели штукатуркой", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Кто имеет право проводить огневые работы во взрывопожароопасных зонах завода?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Любой рабочий с личным инструментом", IsCorrect = false },
                        new Option { Text = "Специально обученные сварщики, имеющие квалификационное удостоверение и оформленный наряд-допуск", IsCorrect = true },
                        new Option { Text = "Стажеры под честное слово мастера", IsCorrect = false },
                        new Option { Text = "Любой сотрудник ночной смены", IsCorrect = false }
                    }
                }
            };
        }

        // =========================================================
        // ГРАЖДАНСКАЯ ОБОРОНА
        // =========================================================
        private static List<Question> GetCivilQuestions()
        {
            return new List<Question>
            {
                new Question
                {
                    QuestionText = "Что означает сигнал гражданской обороны «ВНИМАНИЕ ВСЕМ!» при трансляции заводскими сиренами?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Начало обеденного перерыва в цехе", IsCorrect = false },
                        new Option { Text = "Предупреждение о чрезвычайной ситуации (необходимо включить радио/TV для прослушивания экстренного сообщения)", IsCorrect = true },
                        new Option { Text = "Окончание рабочей недели", IsCorrect = false },
                        new Option { Text = "Учебная проверка уличного освещения", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Куда должен направиться работник завода при получении сигнала тревоги и указании об укрытии в защитном сооружении?",
                    Options = new List<Option>
                    {
                        new Option { Text = "На открытую заводскую парковку", IsCorrect = false },
                        new Option { Text = "В специализированное убежище гражданской обороны согласно плану эвакуации цеха", IsCorrect = true },
                        new Option { Text = "Домой в другой район города", IsCorrect = false },
                        new Option { Text = "В раздевалку административного корпуса", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Каково основное назначение фильтрующего противогаза (например, ГП-7) на складе ГО завода?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Защита от шума работающего пресса", IsCorrect = false },
                        new Option { Text = "Защита органов дыхания, глаз и лица от опасных химических веществ, радиоактивной пыли и аэрозолей", IsCorrect = true },
                        new Option { Text = "Использование при сварочных работах вместо щитка", IsCorrect = false },
                        new Option { Text = "Облегчение дыхания в запыленном цехе", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Кто является начальником гражданской обороны на предприятии (заводе)?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Начальник смены цеха", IsCorrect = false },
                        new Option { Text = "Руководитель (генеральный директор) организации", IsCorrect = true },
                        new Option { Text = "Инженер по охране труда", IsCorrect = false },
                        new Option { Text = "Представитель МЧС района", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что такое индивидуальный противохимический пакет (ИПП), выдаваемый работникам?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Средство для дегазации и обработки открытых участков кожи и одежды при заражении", IsCorrect = true },
                        new Option { Text = "Сухой паек на случай эвакуации", IsCorrect = false },
                        new Option { Text = "Набор для ремонта спецодежды", IsCorrect = false },
                        new Option { Text = "Аптечка для остановки кровотечений", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какая авария техногенного характера наиболее вероятна на крупном химическом заводе?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Внезапное извержение вулкана", IsCorrect = false },
                        new Option { Text = "Авария с выбросом аварийно химически опасных веществ (аммиак, хлор)", IsCorrect = true },
                        new Option { Text = "Масштабное цунами в цехе", IsCorrect = false },
                        new Option { Text = "Нападение диких животных", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что означает термин «эвакуация» в системе гражданской обороны?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Закрытие завода навсегда", IsCorrect = false },
                        new Option { Text = "Организованный вывод или вывоз работников и населения из зон возможных чрезвычайных ситуаций", IsCorrect = true },
                        new Option { Text = "Срочный ремонт станков в ночную смену", IsCorrect = false },
                        new Option { Text = "Передача завода другому владельцу", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какой знак предупреждает о наличии радиоактивной опасности на участке завода?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Зеленый крест на белом фоне", IsCorrect = false },
                        new Option { Text = "Желтый треугольник с тремя изогнутыми лепестками (знак радиационной опасности)", IsCorrect = true },
                        new Option { Text = "Синий квадрат с буквой «П»", IsCorrect = false },
                        new Option { Text = "Красный круг с сигаретой", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что должен иметь при себе работник при эвакуации в загородную зону по планам ГО?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Тяжелый слесарный инструмент со станка", IsCorrect = false },
                        new Option { Text = "Документы, деньги, запас воды и продуктов на первые сутки, комплект одежды", IsCorrect = true },
                        new Option { Text = "Чертежи деталей за прошлый год", IsCorrect = false },
                        new Option { Text = "Запасные детали для личного автомобиля", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какой федеральный орган в РФ руководит гражданской обороной?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Министерство финансов", IsCorrect = false },
                        new Option { Text = "МЧС России (Министерство по делам гражданской обороны и ЧС)", IsCorrect = true },
                        new Option { Text = "Министерство спорта", IsCorrect = false },
                        new Option { Text = "Министерство культуры", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что нужно сделать при угрозе распространения облака хлора с соседнего участка завода?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Спрятаться в подвале или на нижнем этаже здания", IsCorrect = false },
                        new Option { Text = "Подняться на верхние этажи здания, надеть противогаз или ватно-марлевую повязку, смоченную водой", IsCorrect = true },
                        new Option { Text = "Выбежать на открытую уличную площадку", IsCorrect = false },
                        new Option { Text = "Открыть все окна в цехе для проветривания", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что такое простейшее средство защиты органов дыхания при запылении или аварии?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Полнолицевой промышленный противогаз", IsCorrect = false },
                        new Option { Text = "Ватно-марлевая повязка или противопылевой респиратор", IsCorrect = true },
                        new Option { Text = "Полиэтиленовый пакет на голову", IsCorrect = false },
                        new Option { Text = "Обычный шерстяной шарф без сложения", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какое устройство обеспечивает очистку подаваемого воздуха в убежищах ГО?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Обычный бытовой кондиционер", IsCorrect = false },
                        new Option { Text = "Фильтрационно-вентиляционное оборудование (ФВУ)", IsCorrect = true },
                        new Option { Text = "Открытая форточка", IsCorrect = false },
                        new Option { Text = "Вытяжной вентилятор цеха", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Где работник завода может узнать расположение ближайшего убежища ГО?",
                    Options = new List<Option>
                    {
                        new Option { Text = "На информационных стендах по гражданской обороне и в планах эвакуации цеха", IsCorrect = true },
                        new Option { Text = "Спросить у прохожего за проходной", IsCorrect = false },
                        new Option { Text = "Найти в случайном мобильном приложении игры", IsCorrect = false },
                        new Option { Text = "Узнать при покупке билета на поезд", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Как поступать при обнаружении подозрительного бесхозного предмета на территории завода?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Пнуть его ногой или попытаться открыть", IsCorrect = false },
                        new Option { Text = "Не трогать, отойти на безопасное расстояние и немедленно сообщить охране или руководству", IsCorrect = true },
                        new Option { Text = "Забрать себе в личное пользование", IsCorrect = false },
                        new Option { Text = "Спрятать под верстак, чтобы не мешал проходу", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какая категория по гражданской обороне присваивается заводу с важным оборонным значением в зоне возможных разрушений?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Категория не присваивается", IsCorrect = false },
                        new Option { Text = "Категория особой важности, первая или вторая категория по ГО", IsCorrect = true },
                        new Option { Text = "Категория легкой промышленности", IsCorrect = false },
                        new Option { Text = "Сельскохозяйственный объект", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какой коэффициент ослабления радиации (защиты) должно обеспечивать типовое убежище ГО для работников смены?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Не менее 2–3 раз", IsCorrect = false },
                        new Option { Text = "Не менее 1000 раз и более в зависимости от класса защиты", IsCorrect = true },
                        new Option { Text = "Защита от радиации вообще не требуется", IsCorrect = false },
                        new Option { Text = "Ровно в 10 раз", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "К какому виду нештатных формирований ГО (НФГО) относится подразделение для спасательных работ в очагах разрушений?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Санитарный пост", IsCorrect = false },
                        new Option { Text = "Спасательная команда (или спасательная группа)", IsCorrect = true },
                        new Option { Text = "Пост наблюдения за погодой", IsCorrect = false },
                        new Option { Text = "Хозяйственный отдел", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Каков порядок выдачи средств индивидуальной защиты (противогазов) работникам при переводе ГО с мирного на военное время?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Выдаются единовременно на рабочих местах по распоряжению начальника ГО из запасов предприятия", IsCorrect = true },
                        new Option { Text = "Покупаются работниками в аптеках за свой счет", IsCorrect = false },
                        new Option { Text = "Работники сами изготавливают их дома", IsCorrect = false },
                        new Option { Text = "Выдаются только после завершения всех событий", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что предписывают регламенты при обнаружении следов радиоактивного заражения прибором ДП-5 на проходной завода?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Продолжать работу в обычном режиме", IsCorrect = false },
                        new Option { Text = "Оповестить руководство ГО, ввести режимы радиационной защиты, использовать СИЗ и провести дозиметрический контроль", IsCorrect = true },
                        new Option { Text = "Смыть заражение водой из шланга в ливневку", IsCorrect = false },
                        new Option { Text = "Закрыть проходную и разойтись по домам", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какая задача является главной для поста радиационного и химического наблюдения (ПРХН) на заводе?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Тушение крупных пожаров в цехах", IsCorrect = false },
                        new Option { Text = "Своевременное обнаружение радиационного, химического заражения и подача сигналов оповещения", IsCorrect = true },
                        new Option { Text = "Охрана складов от хищений", IsCorrect = false },
                        new Option { Text = "Ремонт станков", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какое требование предъявляется к запасам воды и продовольствия в убежищах ГО завода для укрываемых?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Вода хранится в герметичных емкостях из расчета не менее установленной нормы на человека в сутки", IsCorrect = true },
                        new Option { Text = "Используются открытые водоемы на улице", IsCorrect = false },
                        new Option { Text = "Запасы не создаются вовсе", IsCorrect = false },
                        new Option { Text = "Еду выдают в сухом виде без воды", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что входит в понятие «дезактивация» территории и оборудования завода при ликвидации последствий применения оружия?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Удаление радиоактивных веществ с поверхностей для снижения уровня излучения", IsCorrect = true },
                        new Option { Text = "Уничтожение микробов химикатами", IsCorrect = false },
                        new Option { Text = "Покраска стен свежей краской", IsCorrect = false },
                        new Option { Text = "Уборка масляных пятен с пола", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какое избыточное давление во фронте ударной волны должны выдерживать убежища завода в зоне сильных разрушений?",
                    Options = new List<Option>
                    {
                        new Option { Text = "5 кПа", IsCorrect = false },
                        new Option { Text = "От 100 до 400 кПа и более в зависимости от класса и проекта убежища", IsCorrect = true },
                        new Option { Text = "Давление волны не учитывается", IsCorrect = false },
                        new Option { Text = "Не более 10 кПа", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Как организуется круглосуточное управление гражданской обороной на заводе при угрозе ЧС?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Через дежурно-диспетчерскую службу (пункт управления ГО) предприятия", IsCorrect = true },
                        new Option { Text = "Директор лично дежурит у телефона ночью", IsCorrect = false },
                        new Option { Text = "Управление передается внештатной охране по усмотрению", IsCorrect = false },
                        new Option { Text = "В нерабочее время управление не ведется", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какой нормативный документ определяет создание и содержание объектов гражданской обороны на предприятиях РФ?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Федеральный закон «О гражданской обороне» № 28-ФЗ и подзаконные акты", IsCorrect = true },
                        new Option { Text = "Правила дорожного движения", IsCorrect = false },
                        new Option { Text = "Жилищный кодекс", IsCorrect = false },
                        new Option { Text = "Санитарные нормы школ", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что такое эвакуация предприятий, продолжающих работу в военное время?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Полное закрытие завода и увольнение всех рабочих", IsCorrect = false },
                        new Option { Text = "Перевод производственных мощностей и персонала в безопасные районы с сохранением выпуска продукции", IsCorrect = true },
                        new Option { Text = "Отправка рабочих в отпуск на неопределенный срок", IsCorrect = false },
                        new Option { Text = "Переход завода на выпуск детских игрушек", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Каким документом регламентируется создание нештатных формирований по обеспечению выполнения мероприятий ГО на заводе?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Приказами руководства предприятия на основе законов РФ и указаний МЧС", IsCorrect = true },
                        new Option { Text = "Устными договоренностями бригадиров", IsCorrect = false },
                        new Option { Text = "Заявлениями сотрудников по собственному желанию", IsCorrect = false },
                        new Option { Text = "Трудовым кодексом о премиях", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что такое «дегазирующая рецептура» в комплекте ИПП?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Специальный химический раствор для нейтрализации отравляющих веществ на коже и одежде", IsCorrect = true },
                        new Option { Text = "Жидкость для заправки зажигалок", IsCorrect = false },
                        new Option { Text = "Техническое масло для смазки станков", IsCorrect = false },
                        new Option { Text = "Питьевой раствор при жажде", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какие требования предъявляются к герметичности защитных сооружений ГО при их проверке?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Сооружение должно обеспечивать избыточное давление и надежную изоляцию от внешней зараженной атмосферы", IsCorrect = true },
                        new Option { Text = "Допускаются сквозные щели в дверях для притока свежего воздуха", IsCorrect = false },
                        new Option { Text = "Вентиляция должна работать без фильтров", IsCorrect = false },
                        new Option { Text = "Герметичность проверяется только визуально раз в 10 лет", IsCorrect = false }
                    }
                }
            };
        }

        // =========================================================
        // ПЕРВАЯ ПОМОЩЬ
        // =========================================================
        private static List<Question> GetFirstAidQuestions()
        {
            return new List<Question>
            {
                new Question
                {
                    QuestionText = "Каковы первые действия при обнаружении пострадавшего без сознания у действующего электрооборудования?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Схватить пострадавшего за руки и оттащить", IsCorrect = false },
                        new Option { Text = "Немедленно обесточить электроустановку (выключить рубильник) и только после этого приступать к помощи", IsCorrect = true },
                        new Option { Text = "Полить пострадавшего водой для приведения в чувство", IsCorrect = false },
                        new Option { Text = "Уйти за помощью, оставив пострадавшего без внимания", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Куда звонить для вызова скорой помощи с мобильного телефона при несчастном случае на заводе в РФ?",
                    Options = new List<Option>
                    {
                        new Option { Text = "01 или 101", IsCorrect = false },
                        new Option { Text = "103 или 112", IsCorrect = true },
                        new Option { Text = "102", IsCorrect = false },
                        new Option { Text = "104", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что нужно сделать в первую очередь при артериальном кровотечении (фонтанирующая ярко-красная кровь) из раны на руке?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Промыть рану мыльной водой из-под крана", IsCorrect = false },
                        new Option { Text = "Наложить давящую повязку на рану и, при необходимости, кровоостанавливающий жгут выше раны", IsCorrect = true },
                        new Option { Text = "Дать пострадавшему выпить горячего чая", IsCorrect = false },
                        new Option { Text = "Наложить повязку ниже раны к кисти", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Разрешается ли давать пострадавшему лекарственные препараты (обезболивающие таблетки) до приезда врачей?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Да, обязательно всем пострадавшим", IsCorrect = false },
                        new Option { Text = "Нет, оказывать первую помощь лекарствами лицам без медобразования запрещено из-за риска аллергии", IsCorrect = true },
                        new Option { Text = "Разрешено только начальнику цеха", IsCorrect = false },
                        new Option { Text = "Можно давать любые таблетки из аптечки на выбор", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какой признак указывает на клиническую смерть и необходимость немедленной реанимации (СЛР)?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Наличие синяков на коленях", IsCorrect = false },
                        new Option { Text = "Отсутствие сознания, дыхания и пульса на сонной артерии", IsCorrect = true },
                        new Option { Text = "Повышенная температура тела", IsCorrect = false },
                        new Option { Text = "Громкий крик от боли", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что делать при попадании металлической стружки или пыли в глаз работнику?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Тереть глаз грязными руками или рукавицей", IsCorrect = false },
                        new Option { Text = "Промыть глаз чистой водой (или обратиться в медпункт), не тереть и не удалять глубокие предметы самостоятельно", IsCorrect = true },
                        new Option { Text = "Закапать машинное масло", IsCorrect = false },
                        new Option { Text = "Завязать оба глаза плотной повязкой на сутки", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Как правильно фиксировать руку при переломе костей предплечья?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Зафиксировать только место перелома без суставов", IsCorrect = false },
                        new Option { Text = "Захватить не менее двух суставов (лучезапястный и локтевой)", IsCorrect = true },
                        new Option { Text = "Туго обмотать проволокой без подкладки", IsCorrect = false },
                        new Option { Text = "Оставить руку полностью свободной", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что запрещается делать при термическом ожоге кожи (например, горячим маслом или паром)?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Охлаждать место ожога проточной холодной водой", IsCorrect = false },
                        new Option { Text = "Прокалывать пузыри и смазывать обожженную поверхность жирами, маслами или мазями", IsCorrect = true },
                        new Option { Text = "Накладывать чистую сухую повязку", IsCorrect = false },
                        new Option { Text = "Дать пострадавшему питье", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какую первую помощь оказывают при попадании едкой кислоты или щелочи на кожу в гальваническом цехе?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Обильно промыть пораженный участок кожи струей воды в течение 15–20 минут", IsCorrect = true },
                        new Option { Text = "Засыпать сухим речным песком", IsCorrect = false },
                        new Option { Text = "Протереть бензином", IsCorrect = false },
                        new Option { Text = "Ничего не предпринимать до конца смены", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какое соотношение компрессий и искусственных вдохов при реанимации взрослого?",
                    Options = new List<Option>
                    {
                        new Option { Text = "15 компрессий и 1 вдох", IsCorrect = false },
                        new Option { Text = "30 компрессий и 2 вдоха", IsCorrect = true },
                        new Option { Text = "5 компрессий и 1 вдох", IsCorrect = false },
                        new Option { Text = "Только непрерывные вдохи без нажатий", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что нужно сделать при носовом кровотечении после удара?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Запрокинуть голову назад и лечь на спину", IsCorrect = false },
                        new Option { Text = "Усадить, слегка наклонить голову вперед, приложить холод к переносице и прижать крылья носа на 5–10 минут", IsCorrect = true },
                        new Option { Text = "Закапать машинное масло", IsCorrect = false },
                        new Option { Text = "Вставить металлические предметы", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Как поступить, если человек подавился пищей в столовой (признаки удушья, не может говорить)?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Хлопать по спине ладонью при вертикальном положении", IsCorrect = false },
                        new Option { Text = "Встать сзади, обхватить и выполнить прием Геймлиха (резкие толчки в живот под диафрагму снизу вверх)", IsCorrect = true },
                        new Option { Text = "Заставить выпить литр воды залпом", IsCorrect = false },
                        new Option { Text = "Оставить без внимания", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что входит в обязательное содержимое аптечки первой помощи на заводе?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Набор хирургических скальпелей", IsCorrect = false },
                        new Option { Text = "Маски, перчатки, жгут, бинты, лейкопластырь, устройства для искусственного дыхания", IsCorrect = true },
                        new Option { Text = "Антибиотики широкого спектра", IsCorrect = false },
                        new Option { Text = "Наркотические анальгетики", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какую помощь оказывают при обморожении на открытой площадке зимой?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Растирать отмороженные участки снегом", IsCorrect = false },
                        new Option { Text = "Перевести в тепло, снять холодную одежду, наложить сухую теплоизолирующую повязку, дать теплое питье", IsCorrect = true },
                        new Option { Text = "Опустить конечность в кипяток", IsCorrect = false },
                        new Option { Text = "Смазать концентрированным спиртом", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Где должен находиться пострадавший с подозрением на травму позвоночника при ожидании скорой?",
                    Options = new List<Option>
                    {
                        new Option { Text = "В положении сидя на стуле", IsCorrect = false },
                        new Option { Text = "На жесткой ровной поверхности в том положении, в котором обнаружен (без лишних перемещений)", IsCorrect = true },
                        new Option { Text = "Лежать на боку со сгибанием ног", IsCorrect = false },
                        new Option { Text = "Пострадавшего следует поставить на ноги", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "С какой частотой выполняются компрессии грудной клетки взрослому при реанимации?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Глубина 2–3 см, темп 60 в минуту", IsCorrect = false },
                        new Option { Text = "Глубина 5–6 см, темп 100–120 в минуту", IsCorrect = true },
                        new Option { Text = "Глубина 10 см, темп 150 в минуту", IsCorrect = false },
                        new Option { Text = "Глубина 1 см, темп 40 в минуту", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какова тактика при травматической ампутации пальца или кисти на конвейере?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Выбросить ампутированную часть в мусор", IsCorrect = false },
                        new Option { Text = "Остановить кровотечение, ампутированную часть завернуть в марлю, в пакет и в емкость со льдом (без прямого контакта со льдом)", IsCorrect = true },
                        new Option { Text = "Промыть спиртом и примотать изолентой", IsCorrect = false },
                        new Option { Text = "Положить на батарею отопления", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какую помощь оказать работнику при тепловом ударе в литейном цехе?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Укутать в одеяло и дать кофе", IsCorrect = false },
                        new Option { Text = "Вынести в прохладное помещение, уложить, приподнять ноги, оросить водой, дать прохладное питье", IsCorrect = true },
                        new Option { Text = "Заставить продолжать работу под вентилятором", IsCorrect = false },
                        new Option { Text = "Дать мочегонные средства", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Как правильно накладывать кровоостанавливающий жгут-закрутку из подручных средств на плечо?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Использовать закрутку с подкладкой из ткани на одежду, закрутить до остановки и зафиксировать время наложения", IsCorrect = true },
                        new Option { Text = "Затягивать на голом теле без ограничений по времени", IsCorrect = false },
                        new Option { Text = "Накладывать жгут ниже раны к кисти", IsCorrect = false },
                        new Option { Text = "Подручные средства вообще запрещены", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Каковы особенности помощи при проникающем ранении груди (открытый пневмоторакс со свистом воздуха)?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Заткнуть рану ватой и заклеить пластырем", IsCorrect = false },
                        new Option { Text = "Наложить герметичную повязку (пленкой стороной к ране), зафиксировать края пластырем по периметру, придать полусидячее положение", IsCorrect = true },
                        new Option { Text = "Положить пострадавшего лицом вниз", IsCorrect = false },
                        new Option { Text = "Извлечь торчащие предметы", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что запрещено делать при инородном теле в брюшной полости или груди (например, торчащий прут)?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Фиксировать предмет валиками из бинта вокруг него", IsCorrect = false },
                        new Option { Text = "Самостоятельно извлекать (вытаскивать) предмет из раны", IsCorrect = true },
                        new Option { Text = "Укладывать пострадавшего", IsCorrect = false },
                        new Option { Text = "Накладывать стерильную повязку вокруг", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что делать при обнаружении электрометки и ожогов от тока в точках входа и выхода?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Обработать йодом и заклеить пластырем", IsCorrect = false },
                        new Option { Text = "Наложить сухие чистые повязки на места ожогов, так как электротравма скрыто повреждает внутренние органы", IsCorrect = true },
                        new Option { Text = "Срезать кожу ножницами", IsCorrect = false },
                        new Option { Text = "Смазать солидолом", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какой объем помощи оказывается при судорожном припадке (эпилепсии) на заводе?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Разжимать зубы металлическими предметами", IsCorrect = false },
                        new Option { Text = "Предотвратить травмы головы (мягкое под голову), повернуть на бок после судорог для предотвращения западания языка", IsCorrect = true },
                        new Option { Text = "Удерживать изо всех сил конечности", IsCorrect = false },
                        new Option { Text = "Оставить стоять", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Каковы правила транспортировки пострадавшего с подозрением на травму таза?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Транспортировать в положении сидя", IsCorrect = false },
                        new Option { Text = "Транспортировать на жестких носилках в положении «лягушки» (на спине, ноги согнуты в коленях и разведены)", IsCorrect = true },
                        new Option { Text = "Переносить на мягком матрасе на боку", IsCorrect = false },
                        new Option { Text = "Заставить идти самостоятельно", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что делать при признаках травматического шока (бледность, холодный пот, частый слабый пульс)?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Оставить лежать на голом холодном полу", IsCorrect = false },
                        new Option { Text = "Устранить боль (обездвижить переломы, остановить кровь), согреть, приподнять ноги, вызвать скорую", IsCorrect = true },
                        new Option { Text = "Дать алкоголь для снятия стресса", IsCorrect = false },
                        new Option { Text = "Интенсивно трясти пострадавшего", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Как правильно проводить искусственное дыхание с маской-пленкой?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Запрокинуть голову, поднять подбородок, зажать нос, плотно прижать маску ко рту и сделать 2 плавной вдоха по 1 секунде", IsCorrect = true },
                        new Option { Text = "Делать резкие сильные выдохи 10 секунд без зажатия носа", IsCorrect = false },
                        new Option { Text = "Дуть через нос, закрыв рот руками", IsCorrect = false },
                        new Option { Text = "Надавливать на живот для вдувания", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какая первая помощь при химическом ожоге глаз кислотой или щелочью?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Закапать растительное масло", IsCorrect = false },
                        new Option { Text = "Обильно промыть глаза непрерывной струей воды в течение 15–20 минут, оттягивая веки", IsCorrect = true },
                        new Option { Text = "Прикрыть глаза сухой ватой", IsCorrect = false },
                        new Option { Text = "Протереть сухой салфеткой", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что делать, если у пострадавшего без сознания началась рвота на спине?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Оставить лежать на спине и заставить сглотнуть", IsCorrect = false },
                        new Option { Text = "Повернуть голову набок или повернуть всего пострадавшего на бок для предотвращения аспирации", IsCorrect = true },
                        new Option { Text = "Зажать рот салфеткой", IsCorrect = false },
                        new Option { Text = "Ничего не предпринимать", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "В каких случаях разрешается снимать защитную каску с пострадавшего после падения?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Разрешено снимать всегда для осмотра волос", IsCorrect = false },
                        new Option { Text = "Только если она мешает реанимации (ИВЛ) или оценке состояния, действуя предельно осторожно без смещения шеи", IsCorrect = true },
                        new Option { Text = "Снимать каску запрещено ни при каких обстоятельствах", IsCorrect = false },
                        new Option { Text = "Снимать имеет право только директор", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какой предельный срок нахождения кровоостанавливающего жгута на конечности?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Не более 15 минут в любое время", IsCorrect = false },
                        new Option { Text = "Не более 1 часа летом и не более 30 минут зимой (далее ослабляют с пальцевым прижатием)", IsCorrect = true },
                        new Option { Text = "До 6 часов без ослабления", IsCorrect = false },
                        new Option { Text = "Жгут не снимают вообще до больницы", IsCorrect = false }
                    }
                }
            };
        }

        // =========================================================
        // ОХРАНА ТРУДА
        // =========================================================
        private static List<Question> GetLaborQuestions()
        {
            return new List<Question>
            {
                new Question
                {
                    QuestionText = "Каковы основные обязанности работника завода в области охраны труда по ТК РФ?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Самостоятельно покупать спецсредства в магазине", IsCorrect = false },
                        new Option { Text = "Соблюдать требования охраны труда, правильно применять СИЗ, проходить обучение и медосмотры", IsCorrect = true },
                        new Option { Text = "Участвовать в разработке коллективного договора цеха", IsCorrect = false },
                        new Option { Text = "Назначать мастеров участков", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какой вид инструктажа проводится на рабочем месте с вновь принятым работником перед допуском к самостоятельной работе?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Вводный инструктаж", IsCorrect = false },
                        new Option { Text = "Первичный инструктаж на рабочем месте", IsCorrect = true },
                        new Option { Text = "Внеплановый инструктаж", IsCorrect = false },
                        new Option { Text = "Целевой инструктаж", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что обязан выдать работодатель работнику при занятости на работах с вредными условиями труда?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Денежную компенсацию на покупку костюма", IsCorrect = false },
                        new Option { Text = "Сертифицированные средства индивидуальной защиты (СИЗ) и смывающие средства", IsCorrect = true },
                        new Option { Text = "Спортивный костюм для зарядки", IsCorrect = false },
                        new Option { Text = "Подарочный сертификат", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что делать при обнаружении неисправности станка или защитного ограждения в цехе?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Продолжать работать на пониженной скорости", IsCorrect = false },
                        new Option { Text = "Немедленно прекратить работу, отключить оборудование и сообщить руководителю", IsCorrect = true },
                        new Option { Text = "Попытаться разобрать узел кувалдой", IsCorrect = false },
                        new Option { Text = "Дождаться конца смены и сказать сменщику", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какой документ оформляется для выполнения разовых опасных работ вне постоянных обязанностей (например, на высоте)?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Уголовный кодекс", IsCorrect = false },
                        new Option { Text = "Наряд-допуск на производство работ повышенной опасности", IsCorrect = true },
                        new Option { Text = "Путевой лист погрузчика", IsCorrect = false },
                        new Option { Text = "Расчетная ведомость", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Кем проводятся обязательные предварительные медосмотры при поступлении на завод?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Заводской столовой", IsCorrect = false },
                        new Option { Text = "Медицинской организацией за счет средств работодателя", IsCorrect = true },
                        new Option { Text = "Работником самостоятельно в частной клинике за свой счет", IsCorrect = false },
                        new Option { Text = "Отделом кадров", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что категорически запрещено делать при работе на токарном или сверлильном станке?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Использовать штатный инструмент", IsCorrect = false },
                        new Option { Text = "Работать в перчатках, с распущенными волосами, в шарфах или галстуках", IsCorrect = true },
                        new Option { Text = "Работать в защитных очках", IsCorrect = false },
                        new Option { Text = "Проверять размеры после остановки станка", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Кто допускается к обслуживанию электроустановок и работе с переносным электроинструментом?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Любой желающий в цехе", IsCorrect = false },
                        new Option { Text = "Лица, прошедшие обучение, проверку знаний и имеющие группу по электробезопасности", IsCorrect = true },
                        new Option { Text = "Только инженерный состав", IsCorrect = false },
                        new Option { Text = "Лица младше 16 лет", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что такое специальная оценка условий труда (СОУТ)?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Проверка качества деталей", IsCorrect = false },
                        new Option { Text = "Комплекс мероприятий по оценке уровня воздействия вредных и опасных факторов на работников", IsCorrect = true },
                        new Option { Text = "Оценка директора", IsCorrect = false },
                        new Option { Text = "Инвентаризация стульев в офисе", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Каковы требования к ношению защитной каски в производственных зонах завода?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Каску можно носить в руках", IsCorrect = false },
                        new Option { Text = "Ношение защитной каски обязательно для всех на территории производственных участков повышенной опасности", IsCorrect = true },
                        new Option { Text = "Каску носят только начальники", IsCorrect = false },
                        new Option { Text = "Каску надевают только зимой", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что должен пройти работник перед допуском к самостоятельной работе в части проверки знаний?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Проверку знаний требований охраны труда (экзамен/тестирование)", IsCorrect = true },
                        new Option { Text = "Собеседование по истории завода", IsCorrect = false },
                        new Option { Text = "Сдачу норм ГТО", IsCorrect = false },
                        new Option { Text = "Тест по иностранному языку", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Как должен поступить работник при получении микротравмы (мелкого пореза, ушиба) на рабочем месте?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Замолчать случай, чтобы не портить статистику", IsCorrect = false },
                        new Option { Text = "Обратиться в медпункт за первой помощью и сообщить руководителю для фиксации микроповреждения", IsCorrect = true },
                        new Option { Text = "Замазать зеленкой дома", IsCorrect = false },
                        new Option { Text = "Написать заявление об увольнении", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Разрешается ли загромождать проходы и подходы к электрощитам в производственном цехе?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Да, если это мешает временно", IsCorrect = false },
                        new Option { Text = "Нет, проходы и подходы к щитам должны быть всегда свободными", IsCorrect = true },
                        new Option { Text = "Разрешается в ночную смену", IsCorrect = false },
                        new Option { Text = "Законом не регламентируется", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какой знак предписывает обязательное использование средств защиты органов слуха (наушников)?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Красный треугольник с огнем", IsCorrect = false },
                        new Option { Text = "Синий круг с белым изображением наушников (предписывающий знак)", IsCorrect = true },
                        new Option { Text = "Зеленый квадрат выхода", IsCorrect = false },
                        new Option { Text = "Желтый круг с крестом", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какая мера может применяться к работнику за систематическое нарушение правил охраны труда?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Объявление благодарности", IsCorrect = false },
                        new Option { Text = "Дисциплинарное взыскание (замечание, выговор, увольнение) по ТК РФ", IsCorrect = true },
                        new Option { Text = "Награждение подарком", IsCorrect = false },
                        new Option { Text = "Перевод на повышение", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какова предельная норма подъема и перемещения тяжестей вручную женщинами при чередовании с другой работой?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Не более 5 кг", IsCorrect = false },
                        new Option { Text = "Не более 10 кг", IsCorrect = true },
                        new Option { Text = "Не более 15 кг", IsCorrect = false },
                        new Option { Text = "До 50 кг", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "В течение какого срока работодатель обязан расследовать легкий несчастный случай на производстве?",
                    Options = new List<Option>
                    {
                        new Option { Text = "В течение 3 календарных дней", IsCorrect = false },
                        new Option { Text = "В течение 3 рабочих дней со дня образования комиссии", IsCorrect = true },
                        new Option { Text = "В течение 1 месяца", IsCorrect = false },
                        new Option { Text = "В течение 24 часов", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какая группа по электробезопасности требуется неэлектротехническому персоналу (операторам станков с электроинструментом)?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Первая группа (I)", IsCorrect = true },
                        new Option { Text = "Третья группа (III)", IsCorrect = false },
                        new Option { Text = "Пятая группа (V)", IsCorrect = false },
                        new Option { Text = "Группа не требуется", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Каковы требования к проведению работ на высоте (2 метра и более от поверхности)?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Выполняются без страховок на усмотрение", IsCorrect = false },
                        new Option { Text = "С оформлением наряда-допуска и обязательным применением систем безопасности (привязи, страховочные канаты)", IsCorrect = true },
                        new Option { Text = "Достаточно подложить деревянный ящик", IsCorrect = false },
                        new Option { Text = "Разрешено работать только ночью", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Кем утверждается инструкция по охране труда для конкретной профессии на заводе?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Профсоюзом единолично", IsCorrect = false },
                        new Option { Text = "Работодателем с учетом мнения выборного профсоюзного органа", IsCorrect = true },
                        new Option { Text = "Заводоуправлением без согласований", IsCorrect = false },
                        new Option { Text = "Пожарной инспекцией", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Каковы особенности проведения внепланового инструктажа по охране труда?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Проводится раз в 5 лет", IsCorrect = false },
                        new Option { Text = "Проводится при изменениях техпроцесса, замене оборудования или нарушениях требований охраны труда", IsCorrect = true },
                        new Option { Text = "Проводится только после отпуска", IsCorrect = false },
                        new Option { Text = "Проводится ежемесячно", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какой документ составляется по результатам расследования тяжелого или смертельного несчастного случая?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Акт формы Н-1 по каждому пострадавшему", IsCorrect = true },
                        new Option { Text = "Обычная справка кадров", IsCorrect = false },
                        new Option { Text = "Книга жалоб", IsCorrect = false },
                        new Option { Text = "Бухгалтерский баланс", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "С какой периодичностью проводится повторный инструктаж по охране труда на рабочем месте?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Не реже одного раза в полгода (каждые 6 месяцев)", IsCorrect = true },
                        new Option { Text = "Один раз в 3 года", IsCorrect = false },
                        new Option { Text = "Ежемесячно", IsCorrect = false },
                        new Option { Text = "Один раз в 10 лет", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какой класс условий труда (вредности) устанавливается по СОУТ при выявлении вредных факторов, вызывающих профзаболевания легкой степени (класс 3.3)?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Класс 1 (оптимальные)", IsCorrect = false },
                        new Option { Text = "Класс 2 (допустимые)", IsCorrect = false },
                        new Option { Text = "Класс 3.3 (вредные условия 3-й степени)", IsCorrect = true },
                        new Option { Text = "Класс 4 (опасные)", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какие требования предъявляются к испытаниям ручного электроинструмента перед выдачей?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Инструмент выдается без проверок из коробки", IsCorrect = false },
                        new Option { Text = "Инструмент подлежит периодической проверке (сопротивление изоляции, заземление) не реже 1 раза в 6 месяцев", IsCorrect = true },
                        new Option { Text = "Проверка силами рабочего визуально", IsCorrect = false },
                        new Option { Text = "Испытания раз в 10 лет", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Какая ответственность предусмотрена УК РФ за нарушение охраны труда, повлекшее по неосторожности смерть человека?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Устное замечание мастера", IsCorrect = false },
                        new Option { Text = "Уголовная ответственность должностного лица (включая лишение свободы)", IsCorrect = true },
                        new Option { Text = "Штраф 500 рублей", IsCorrect = false },
                        new Option { Text = "Лишение премии за месяц", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Что входит в понятие «производственный риск» в системе управления охраной труда (СУОТ)?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Риск задержки зарплаты", IsCorrect = false },
                        new Option { Text = "Сочетание вероятности возникновения опасного события и тяжести его последствий для здоровья", IsCorrect = true },
                        new Option { Text = "Риск брака деталей", IsCorrect = false },
                        new Option { Text = "Колебания цен на металл", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Каковы обязанности работодателя при возникновении несчастного случая в части передачи информации?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Сокрыть факт происшествия", IsCorrect = false },
                        new Option { Text = "Организовать помощь, предотвратить развитие аварии и направить извещения в уполномоченные органы", IsCorrect = true },
                        new Option { Text = "Сообщить через неделю письмом", IsCorrect = false },
                        new Option { Text = "Опросить свидетелей без фиксации", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Кем формируется комиссия по расследованию несчастного случая на производстве?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Пострадавшим самостоятельно", IsCorrect = false },
                        new Option { Text = "Работодателем (приказом) в составе не менее трех человек (специалист по ОТ, представитель профсоюза)", IsCorrect = true },
                        new Option { Text = "Случайным жребием в цехе", IsCorrect = false },
                        new Option { Text = "Охраной проходной", IsCorrect = false }
                    }
                },
                new Question
                {
                    QuestionText = "Каким документом регламентируется порядок обучения по охране труда в РФ?",
                    Options = new List<Option>
                    {
                        new Option { Text = "Постановление Правительства об утверждении Правил обучения по охране труда", IsCorrect = true },
                        new Option { Text = "Правила дорожного движения", IsCorrect = false },
                        new Option { Text = "Устав автопарка", IsCorrect = false },
                        new Option { Text = "Саннормы школ", IsCorrect = false }
                    }
                }
            };
        }
    }
}