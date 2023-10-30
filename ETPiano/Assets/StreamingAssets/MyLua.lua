defineChord("minor7", {0, 3, 7, 10})
defineChord("major7", {0, 4, 7, 10})
defineChord("maj7", {0, 4, 7, 11})
defineChord("dim7", {0, 3, 6, 10})

voiceAround("C4")

majorScale = {0, 2, 4, 5, 7, 9, 11, 12}


function start()
    while(true) 
    do
		playChord("C4", "major7")
		wait(1)
		
        
    end
end
