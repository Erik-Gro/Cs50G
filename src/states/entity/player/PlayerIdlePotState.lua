PlayerIdlePotState = Class { __includes = EntityIdleState }

function PlayerIdlePotState:init(entity, dungeon)
    self.entity = entity
    self.dungeon = dungeon
    self.pot = self.entity.Pot
    -- render offset for spaced character sprite (negated in render function of state)
    -- self.entity.offsetY = 5
    -- self.entity.offsetX = 0
    self.entity:changeAnimation('idle-pot-' .. self.entity.direction)
end

function PlayerIdlePotState:enter(params)
    -- render offset for spaced character sprite (negated in render function of state)
    self.entity.offsetY = 5
    self.entity.offsetX = 0
    --self.entity:changeAnimation('idle-pot' .. self.entity.direction)
end

function PlayerIdlePotState:update(dt)
    if love.keyboard.isDown('left') or love.keyboard.isDown('right') or
        love.keyboard.isDown('up') or love.keyboard.isDown('down') then
        self.entity:changeState('walk-pot')
    elseif love.keyboard.isDown('return') then
        self.pot.projectile = true
        self.pot.direction = self.entity.direction
        self.pot.entities = self.dungeon.currentRoom.entities
        self.entity:changeState('idle')
    end
end

-- function PlayerIdlePotState:render()
--     local anim = self.entity.currentAnimation
--     love.graphics.draw(gTextures[anim.texture], gFrames[anim.texture][anim:getCurrentFrame()],
--         math.floor(self.entity.x - self.entity.offsetX), math.floor(self.entity.y - self.entity.offsetY))

--     -- love.graphics.setColor(255, 0, 255, 255)
--     -- love.graphics.rectangle('line', self.entity.x, self.entity.y, self.entity.width, self.entity.height)
--     -- love.graphics.setColor(255, 255, 255, 255)
-- end
