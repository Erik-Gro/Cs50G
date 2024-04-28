--[[
    GD50
    Match-3 Remake

    -- Tile Class --

    Author: Colton Ogden
    cogden@cs50.harvard.edu

    The individual tiles that make up our game board. Each Tile can have a
    color and a variety, with the varietes adding extra points to the matches.
]]

Tile = Class {}

function Tile:init(x, y, color, variety)
    -- board positions
    self.gridX = x
    self.gridY = y
    self.explode = 0
    -- coordinate positions
    self.x = (self.gridX - 1) * 32
    self.y = (self.gridY - 1) * 32

    -- tile appearance/points
    self.color = color
    self.variety = variety
    self.shiny = math.random(5)
end

function Tile:render(x, y, gridX, gridY)
    -- draw shadow
    if self.shiny == 1 then
        -- multiply so drawing white rect makes it brighter
        -- love.graphics.setBlendMode('add')

        -- love.graphics.setColor(250, 250, 51, 96 / 255)
        -- love.graphics.rectangle('fill', (x - 1) * 32 + (VIRTUAL_WIDTH - 272),
        --     (y - 1) * 32 + 16, 32, 32, 4)

        -- -- back to alpha
        -- love.graphics.setBlendMode('alpha')
        love.graphics.setColor(250 / 255, 250 / 255, 51 / 255, 1)
        love.graphics.setLineWidth(4)
        love.graphics.rectangle('line', gridX * 32 - 32 + (VIRTUAL_WIDTH - 272),
            gridY * 32 - 32 + 16, 32, 32, 4)
    end
    love.graphics.setColor(34, 32, 52, 255)
    love.graphics.draw(gTextures['main'], gFrames['tiles'][self.color][self.variety],
        self.x + x + 2, self.y + y + 2)

    -- draw tile itself
    love.graphics.setColor(255, 255, 255, 255)
    love.graphics.draw(gTextures['main'], gFrames['tiles'][self.color][self.variety],
        self.x + x, self.y + y)
end
